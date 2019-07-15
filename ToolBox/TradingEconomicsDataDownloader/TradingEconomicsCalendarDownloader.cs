/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using Newtonsoft.Json;
using QuantConnect.Data.Auxiliary;
using QuantConnect.Data.Custom.TradingEconomics;
using QuantConnect.Logging;
using QuantConnect.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuantConnect.ToolBox.TradingEconomicsDataDownloader
{
    /// <summary>
    /// Trading Economics Calendar Downloader class
    /// </summary>
    public class TradingEconomicsCalendarDownloader : TradingEconomicsDataDownloader
    {
        private readonly MapFileResolver _mapfileResolver;
        private readonly string _destinationFolder;
        private readonly DateTime _fromDate;
        private readonly DateTime _toDate;
        private readonly RateGate _requestGate;

        public TradingEconomicsCalendarDownloader(string destinationFolder)
        {
            _fromDate = new DateTime(2000, 10, 01);
            _toDate = DateTime.Now;
            _destinationFolder = destinationFolder;
            // Rate limits on Trading Economics is one request per second
            _requestGate = new RateGate(1, TimeSpan.FromSeconds(1));
            _mapfileResolver = MapFileResolver.Create(Globals.DataFolder, Market.USA);

            Directory.CreateDirectory(_destinationFolder);
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns>True if process all downloads successfully</returns>
        public override bool Run()
        {
            Log.Trace("TradingEconomicsCalendarDownloader.Run(): Begin downloading calendar data");
            var stopwatch = Stopwatch.StartNew();
            var data = new List<TradingEconomicsCalendar>();
            var availableFiles = Directory.GetFiles(_destinationFolder, "*.zip", SearchOption.AllDirectories)
                .Select(x => DateTime.ParseExact(Path.GetFileName(x).Substring(8), "yyyyMMdd", CultureInfo.InvariantCulture))
                .ToHashSet();

            var startUtc = _fromDate;
            while (startUtc < _toDate)
            {
                try
                {
                    var endUtc = startUtc.AddMonths(1).AddDays(-1);

                    Log.Trace($"TradingEconomicsCalendarDownloader.Run(): Collecting calendar data from {startUtc:yyyy-MM-dd} to {endUtc:yyyy-MM-dd}");

                    if (availableFiles.Contains(endUtc))
                    {
                        Log.Trace($"TradingEconomicsCalendarDownloader.Run(): Skipping data because it already exists for month: {startUtc:MMMM}");
                        startUtc = startUtc.AddMonths(1);
                        continue;
                    }

                    _requestGate.WaitToProceed(TimeSpan.FromSeconds(1));

                    var content = Get(startUtc, endUtc).Result;
                    var collection = JsonConvert.DeserializeObject<List<TradingEconomicsCalendar>>(content);

                    // Only write data that contains the "actual" field so that we get the final
                    // piece of unchanging data in order to maintain backwards consistency with
                    // the given data since we can't get historical snapshots of the data
                    var onlyActual = collection
                        .Where(x => !string.IsNullOrEmpty(x.Actual))
                        .ToList();

                    var totalFiltered = collection.Count - onlyActual.Count;

                    if (totalFiltered != 0)
                    {
                        Log.Trace($"TradingEconomicsCalendarDownloader.Run(): Filtering {totalFiltered}/{collection.Count} entries because they contain no 'actual' field");
                    }

                    data.AddRange(onlyActual);

                    startUtc = startUtc.AddMonths(1);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"TradingEconomicsCalendarDownloader.Run(): Error parsing data for date {startUtc:yyyyMMdd}");
                    return false;
                }
            }

            Log.Trace($"TradingEconomicsCalendarDownloader.Run(): {data.Count} calendar entries read in {stopwatch.Elapsed}");

            foreach (var kvp in data.GroupBy(GetTicker))
            {
                // Create the destination directory, otherwise we risk having it fail when we move
                // the temp file to its final destination
                Directory.CreateDirectory(Path.Combine(_destinationFolder, kvp.Key));

                foreach (var calendarDataByDate in kvp.GroupBy(x => x.LastUpdate.Date))
                {
                    var date = calendarDataByDate.Key.ToString("yyyyMMdd");
                    var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.json");
                    var tempZipPath = tempPath.Replace(".json", ".zip");
                    var finalZipPath = Path.Combine(_destinationFolder, kvp.Key, $"{date}.zip");

                    if (File.Exists(finalZipPath))
                    {
                        Log.Trace($"TradingEconomicsCalendarDownloader.Run(): {date} - Skipping file because it already exists: {finalZipPath}");
                        continue;
                    }

                    try
                    {
                        var contents = JsonConvert.SerializeObject(calendarDataByDate.ToList());
                        Log.Trace($"TradingEconomicsCalendarDownloader.Run(): {date} - Writing file before compression: {tempPath}");
                        File.WriteAllText(tempPath, contents);

                        Log.Trace($"TradingEconomicsCalendarDownloader.Run(): {date} - Compressing to: {tempZipPath}");
                        // Write out this data string to a zip file
                        Compression.Zip(tempPath, tempZipPath, $"{date}.json", true);

                        Log.Trace($"TradingEconomicsCalendarDownloader.Run(): {date} - Moving temp file: {tempZipPath} to {finalZipPath}");
                        File.Move(tempZipPath, finalZipPath);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, $"TradingEconomicsCalendarDownloader.Run(): {date} - Error creating zip file for ticker: {kvp.Key}");
                        return false;
                    }
                }
            }

            Log.Trace($"TradingEconomicsCalendarDownloader.Run(): Finished in {stopwatch.Elapsed}");
            return true;
        }

        /// <summary>
        /// Get Trading Economics Calendar data for a given this start and end times(in UTC).
        /// </summary>
        /// <param name="startUtc">Start time of the data in UTC</param>
        /// <param name="endUtc">End time of the data in UTC</param>
        /// <returns>String representing data for this date range</returns>
        public override Task<string> Get(DateTime startUtc, DateTime endUtc)
        {
            var url = $"/calendar/country/all/{startUtc:yyyy-MM-dd}/{endUtc:yyyy-MM-dd}";
            return HttpRequester(url);
        }

        /// <summary>
        /// Gets the ticker. If the ticker is empty, we return the category and country of the calendar
        /// </summary>
        /// <param name="tradingEconomicsCalendar">Calendar data</param>
        /// <returns>Ticker or category + country data</returns>
        private string GetTicker(TradingEconomicsCalendar tradingEconomicsCalendar)
        {
            var ticker = tradingEconomicsCalendar.Ticker;
            var defaultTicker = (tradingEconomicsCalendar.Category + tradingEconomicsCalendar.Country).ToLower().Replace(" ", "-");

            if (string.IsNullOrWhiteSpace(ticker))
            {
                return defaultTicker;
            }

            return ticker.ToLower().Replace(" ", "-");
        }
    }
}