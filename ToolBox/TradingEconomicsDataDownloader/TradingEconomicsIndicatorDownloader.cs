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
using Newtonsoft.Json.Linq;
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
    /// Trading Economics Indicators Downloader class
    /// </summary>
    public class TradingEconomicsIndicatorDownloader : TradingEconomicsDataDownloader
    {
        private readonly MapFileResolver _mapFileResolver;
        private readonly string _destinationFolder;
        private readonly RateGate _requestGate;
        private readonly DateTime _fromDate;
        private readonly DateTime _toDate;
        private string _indicator;

        public TradingEconomicsIndicatorDownloader(DateTime fromDate, DateTime toDate, string destinationFolder)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            _destinationFolder = destinationFolder;
            _requestGate = new RateGate(1, TimeSpan.FromSeconds(1));
            _mapFileResolver = MapFileResolver.Create(Globals.DataFolder, Market.USA);

            Directory.CreateDirectory(destinationFolder);
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns>True if process all downloads successfully</returns>
        public override bool Run()
        {
            Log.Trace("TradingEconomicsIndicatorDownloader.Run(): Begin downloading indicator data");

            var stopwatch = Stopwatch.StartNew();

            // Makes sure we don't request for data immediately after we query the `/indicators` endpoint
            _requestGate.WaitToProceed(TimeSpan.FromSeconds(1));

            Log.Trace("TradingEconomicsIndicatorDownloader.Run(): Getting list of indicators");

            var json = HttpRequester("/indicators").Result;
            var indicators = JArray.Parse(json).Select(x => x["Category"].Value<string>().ToLower());
            var availableFiles = Directory.GetFiles(Path.Combine(_destinationFolder, "indicator"), "*.zip", SearchOption.AllDirectories)
                .Select(x => DateTime.ParseExact(Path.GetFileName(x).Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture))
                .ToHashSet();

            foreach (var indicator in indicators)
            {
                _indicator = indicator;

                var data = new List<TradingEconomicsIndicator>();

                var startUtc = _fromDate;
                while (startUtc < _toDate)
                {
                    try
                    {
                        var endUtc = startUtc.AddMonths(1).AddDays(-1);

                        if (availableFiles.Contains(endUtc))
                        {
                            Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): Skipping data because it already exists for month: {startUtc:MMMM}");
                            startUtc = startUtc.AddMonths(1);
                            continue;
                        }

                        Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): Collecting data for indicator: {indicator} - from {startUtc:yyyy-MM-dd} to {endUtc:yyyy-MM-dd}");

                        _requestGate.WaitToProceed(TimeSpan.FromSeconds(1));

                        var content = Get(startUtc, endUtc).Result;
                        var collection = JsonConvert.DeserializeObject<List<TradingEconomicsIndicator>>(content);

                        data.AddRange(collection);
                        startUtc = startUtc.AddMonths(1);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, $"TradingEconomicsIndicatorDownloader.Run(): Error parsing data for date {startUtc:yyyyMMdd}");
                        return false;
                    }
                }

                Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): {data.Count} {indicator} indicator entries read in {stopwatch.Elapsed}");

                foreach (var kvp in data.GroupBy(GetTicker))
                {
                    // Create the destination directory, otherwise we risk having it fail when we move
                    // the temp file to its final destination
                    Directory.CreateDirectory(Path.Combine(_destinationFolder, "indicator", kvp.Key));

                    foreach (var indicatorByDate in kvp.GroupBy(x => x.LastUpdate))
                    {
                        var date = indicatorByDate.Key.ToString("yyyyMMdd");
                        var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.json");
                        var tempZipPath = tempPath.Replace(".json", ".zip");
                        var finalZipPath = Path.Combine(_destinationFolder, "indicator", kvp.Key, $"{date}.zip");

                        if (File.Exists(finalZipPath))
                        {
                            Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): {date} - Skipping file because it already exists: {finalZipPath}");
                            continue;
                        }

                        try
                        {
                            var contents = JsonConvert.SerializeObject(indicatorByDate.ToList());

                            Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): {date} - Writing file before compression: {tempPath}");
                            File.WriteAllText(tempPath, contents);

                            Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): {date} - Compressing to: {tempZipPath}");
                            // Write out this data string to a zip file
                            Compression.Zip(tempPath, tempZipPath, $"{date}.json", true);

                            Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): {date} - Moving temp file: {tempZipPath} to {finalZipPath}");
                            File.Move(tempZipPath, finalZipPath);
                        }
                        catch (Exception e)
                        {
                            Log.Error(e, $"TradingEconomicsIndicatorDownloader.Run(): {date} - Error creating zip file for ticker: {kvp.Key}");
                            return false;
                        }
                    }
                }
            }

            Log.Trace($"TradingEconomicsIndicatorDownloader.Run(): Finished in {stopwatch.Elapsed}");
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
            var url = $"/historical/country/all/indicator/{_indicator}/{startUtc:yyyy-MM-dd}/{endUtc:yyyy-MM-dd}";
            return HttpRequester(url);
        }

        /// <summary>
        /// Gets the ticker. If the ticker is empty, we return the category and country of the calendar
        /// </summary>
        /// <param name="tradingEconomicsIndicator">Indicator data</param>
        /// <returns>Ticker or category + country data</returns>
        private string GetTicker(TradingEconomicsIndicator tradingEconomicsIndicator)
        {
            var ticker = tradingEconomicsIndicator.HistoricalDataSymbol;
            var defaultTicker = (tradingEconomicsIndicator.Category + tradingEconomicsIndicator.Country).ToLower().Replace(" ", "-");

            if (string.IsNullOrWhiteSpace(ticker))
            {
                return defaultTicker;
            }

            return ticker.ToLower().Replace(" ", "-");
        }
    }
}