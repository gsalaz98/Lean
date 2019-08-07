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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using QuantConnect.Configuration;
using QuantConnect.Data;
using QuantConnect.Data.Auxiliary;
using QuantConnect.Data.Custom.BrainData;
using QuantConnect.Interfaces;
using QuantConnect.Logging;
using QuantConnect.Util;

namespace QuantConnect.ToolBox.BrainDataConverter
{
    public class BrainDataConverter
    {
        private MapFileResolver _mapFileResolver;
        private DirectoryInfo _sourceDirectory;
        private DirectoryInfo _destinationDirectory;


        /// <summary>
        /// Creates an instance of the object. Note: construct your <see cref="DirectoryInfo"/> instance
        /// to point at the `braindata` folder, but don't specify the sentiment or stock ranking folders
        /// </summary>
        /// <param name="sourceDirectory">Directory where we load raw data from</param>
        /// <param name="destinationDirectory">The data's final destination directory</param>
        public BrainDataConverter(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory)
        {
            _mapFileResolver = Composer.Instance.GetExportedValueByTypeName<IMapFileProvider>(Config.Get("map-file-provider", "LocalDiskMapFileProvider"))
                .Get(Market.USA);

            _sourceDirectory = sourceDirectory;
            _destinationDirectory = destinationDirectory;
        }

        /// <summary>
        /// Converts the data by date
        /// </summary>
        /// <param name="date">Date to convert data from</param>
        /// <returns>Boolean value indicating success status</returns>
        public bool Convert(DateTime date)
        {
            var success = true;

            var sentimentSevenSourceFile = new FileInfo(Path.Combine(_sourceDirectory.FullName, "sentiment", $"sent_us_ndays_7_{date:yyyyMMdd}.csv"));
            var sentimentSevenFinalDirectory = new DirectoryInfo(Path.Combine(_destinationDirectory.FullName, "sentiment_us_weekly"));
            var sentimentThirtySourceFile = new FileInfo(Path.Combine(_sourceDirectory.FullName, "sentiment", $"sent_us_ndays_30_{date:yyyyMMdd}.csv"));
            var sentimentThirtyFinalDirectory = new DirectoryInfo(Path.Combine(_destinationDirectory.FullName, "sentiment_us_monthly"));

            var rankingFiveSourceFile = new FileInfo(Path.Combine(_sourceDirectory.FullName, "rankings", $"ml_alpha_5_days_{date:yyyyMMdd}.csv"));
            var rankingFiveFinalDirectory = new DirectoryInfo(Path.Combine(_destinationDirectory.FullName, "rankings_five_day"));
            var rankingTenSourceFile = new FileInfo(Path.Combine(_sourceDirectory.FullName, "rankings", $"ml_alpha_10_days_{date:yyyyMMdd}.csv"));
            var rankingTenFinalDirectory = new DirectoryInfo(Path.Combine(_destinationDirectory.FullName, "rankings_ten_day"));

            // Create the directories so that we don't get an error if we try to move a file to a non-existent directory
            sentimentSevenFinalDirectory.Create();
            sentimentThirtyFinalDirectory.Create();
            rankingFiveFinalDirectory.Create();
            rankingTenFinalDirectory.Create();

            // Multiple try...catch so that we can attempt to write all files before exiting
            try
            {
                using (var sentimentStream = sentimentSevenSourceFile.OpenRead())
                {
                    WriteToFile(
                        Process<BrainDataSentimentWeekly>(date, sentimentStream),
                        sentimentSevenFinalDirectory
                    );
                }
            }
            catch (Exception e)
            {
                Log.Error(e, $"BrainDataConverter.Convert(): Failed to process seven day sentiment data: {sentimentSevenSourceFile.FullName}");
                success = false;
            }
            try
            {
                using (var sentimentStream = sentimentThirtySourceFile.OpenRead())
                {
                    WriteToFile(
                        Process<BrainDataSentimentMonthly>(date, sentimentStream),
                        sentimentThirtyFinalDirectory
                    );
                }
            }
            catch (Exception e)
            {
                Log.Error(e, $"BrainDataConverter.Convert(): Failed to process thirty day sentiment data: {sentimentThirtySourceFile.FullName}");
                success = false;
            }

            try
            {
                using (var rankingStream = rankingFiveSourceFile.OpenRead())
                {
                    WriteToFile(
                        Process<BrainDataRankingsFiveDay>(date, rankingStream),
                        rankingFiveFinalDirectory
                    );
                }
            }
            catch (Exception e)
            {
                Log.Error(e, $"BrainDataConverter.Convert(): Failed to process five day ranking data: {rankingFiveSourceFile.FullName}");
                success = false;
            }
            try
            {
                using (var rankingStream = rankingTenSourceFile.OpenRead())
                {
                    WriteToFile(
                        Process<BrainDataRankingsTenDay>(date, rankingStream),
                        rankingTenFinalDirectory
                    );
                }
            }
            catch (Exception e)
            {
                Log.Error(e, $"BrainDataConverter.Convert(): Failed to process ten day ranking data: {rankingTenSourceFile.FullName}");
                success = false;
            }

            return success;
        }

        private IEnumerable<T> Process<T>(DateTime date, Stream sourceStream)
            where T : BaseData, new()
        {
            Log.Trace($"BrainDataConverter.Process[{typeof(T).Name}](): Begin converting data");

            using (var reader = new StreamReader(sourceStream))
            {
                var i = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    i++;

                    // We want to skip some lines, like headers. This is a detail
                    // left for the user to implement since we don't know the shape of the data
                    if (ShouldSkipLine(line))
                    {
                        Log.Trace($"BrainDataConverter.Process[{typeof(T).Name}](): Skipping line {i} due to successful line skip condition");
                        continue;
                    }

                    T data;
                    try
                    {
                        // Load the data into an instance of T. Since this operation is prone to failure, we've
                        // wrapped it around a try...catch block so that one line doesn't cause our job to fail
                        data = GetDataInstanceFromRaw<T>(line);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, $"BrainDataConverter.Process[{typeof(T).Name}](): Failed to construct data instance from raw data at line {i}");
                        continue;
                    }

                    // If we can select the date of the instance, use it instead of the date we're processing the file for
                    var selectedDate = data.Time != DateTime.MinValue ? data.Time : date;

                    // In the case that we don't want to use mapping, override `MapTicker` to return the same ticker
                    // that was passed in. Null indicates that we tried to map the symbol, but failed to do so.
                    var mappedSymbol = MapTicker(data.Symbol.Value, selectedDate, i);
                    if (string.IsNullOrEmpty(mappedSymbol))
                    {
                        Log.Trace($"BrainDataConverter.Process[{typeof(T).Name}](): Skipping ticker {data.Symbol.Value} because it resolved to null");
                        continue;
                    }

                    // Make sure we update the mapped symbol so that we can distinguish tickers by mapped symbol
                    data.Symbol = data.Symbol.UpdateMappedSymbol(mappedSymbol);

                    yield return data;
                }
            }
        }

        /// <summary>
        /// Maps the ticker to what the ticker was at a given date
        /// </summary>
        /// <param name="ticker">Stock ticker</param>
        /// <param name="date">Date to rename to</param>
        /// <param name="line">Line count, used for logging</param>
        /// <returns>Renamed ticker, same ticker, or null</returns>
        private string MapTicker(string ticker, DateTime date, int line)
        {
            var mapFile = _mapFileResolver.ResolveMapFile(ticker, date);
            if (!mapFile.Any())
            {
                Log.Error($"BrainDataConverter.MapTicker(): Failed to get mapfile for ticker {ticker} at line {line} on {date:yyyy-MM-dd}");
                return null;
            }

            var newTicker = mapFile.GetMappedSymbol(date);
            if (string.IsNullOrEmpty(newTicker))
            {
                Log.Error($"BrainDataConverter.MapTicker(): Failed to get mapped symbol for old ticker {ticker} at line {line} on {date:yyyy-MM-dd}");
                return null;
            }
            // This can potentially be a point of failure, so let's log just in case
            if (ticker != newTicker)
            {
                Log.Trace($"BrainDataConverter.MapTicker(): Ticker changed from {ticker} to {newTicker} on {date:yyyy-MM-dd}");
            }

            return newTicker;
        }

        /// <summary>
        /// Skips the header row of raw Brain Data data
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool ShouldSkipLine(string line)
        {
            return line.StartsWith("DATE");
        }

        /// <summary>
        /// Converts formatted data to an instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">BaseData derived type</typeparam>
        /// <param name="ticker">Ticker of the data we're processing</param>
        /// <param name="line">Line of formatted data. This should come from the Data Folder</param>
        /// <returns>Instance of T</returns>
        private T GetDataInstance<T>(string ticker, string line)
            where T : BaseData, new()
        {
            var mockSubscription = new SubscriptionDataConfig(
                typeof(T),
                Symbol.Create(ticker, SecurityType.Base, Market.USA),
                Resolution.Daily,
                TimeZones.Utc,
                TimeZones.Utc,
                false,
                false,
                false);

            var instance = new T();
            return (T)instance.Reader(mockSubscription, line, DateTime.MinValue, false);
        }

        /// <summary>
        /// Converts raw data to instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">BaseData derived type</typeparam>
        /// <param name="line">Line of unformatted/raw data</param>
        /// <returns>Instance of T</returns>
        private T GetDataInstanceFromRaw<T>(string line)
            where T : BaseData, new()
        {
            var csv = line.ToCsv();

            if (typeof(T) == typeof(BrainDataSentimentWeekly))
            {
                return (T)(BaseData)new BrainDataSentimentWeekly
                {
                    Time = DateTime.ParseExact(csv[0], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Symbol = Symbol.Create(csv[1], SecurityType.Base, Market.USA),
                    Sector = csv[2],
                    SentimentScore = System.Convert.ToDecimal(csv[3], CultureInfo.InvariantCulture)
                };
            }
            if (typeof(T) == typeof(BrainDataSentimentMonthly))
            {
                return (T)(BaseData)new BrainDataSentimentMonthly
                {
                    Time = DateTime.ParseExact(csv[0], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Symbol = Symbol.Create(csv[1], SecurityType.Base, Market.USA),
                    Sector = csv[2],
                    SentimentScore = System.Convert.ToDecimal(csv[3], CultureInfo.InvariantCulture)
                };
            }
            if (typeof(T) == typeof(BrainDataRankingsFiveDay))
            {
                return (T)(BaseData)new BrainDataRankingsFiveDay
                {
                    Time = DateTime.ParseExact(csv[0], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Symbol = Symbol.Create(csv[2], SecurityType.Base, Market.USA),
                    RankingScore = System.Convert.ToDecimal(csv[3], CultureInfo.InvariantCulture)
                };
            }
            if (typeof(T) == typeof(BrainDataRankingsTenDay))
            {
                return (T)(BaseData)new BrainDataRankingsTenDay
                {
                    Time = DateTime.ParseExact(csv[0], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Symbol = Symbol.Create(csv[2], SecurityType.Base, Market.USA),
                    RankingScore = System.Convert.ToDecimal(csv[3], CultureInfo.InvariantCulture)
                };
            }

            throw new NotImplementedException($"Type \"{typeof(T).Name}\" is not supported");
        }

        private void WriteToFile<T>(IEnumerable<T> data, DirectoryInfo finalDirectory)
            where T : BaseData, new()
        {
            var typeName = typeof(T).Name;

            foreach (var kvp in data.GroupBy(x => x.Symbol.Value))
            {
                var tempFile = new FileInfo(Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.tmp"));
                var finalFile = new FileInfo(Path.Combine(finalDirectory.FullName, $"{kvp.Key.ToLowerInvariant()}.csv"));
                var backupFinalFile = new FileInfo(Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.csv"));

                try
                {
                    var finalContents = new List<T>();
                    if (finalFile.Exists)
                    {
                        finalContents = File.ReadAllLines(finalFile.FullName)
                            .Select(x => GetDataInstance<T>(kvp.Key, x))
                            .ToList();
                    }

                    finalContents.AddRange(kvp);
                    var csvContents = finalContents.OrderBy(x => x.Time)
                        .Select(x => Serialize(x))
                        .Distinct()
                        .ToList();

                    Log.Trace($"BrainDataConverter.WriteToFile[{typeName}](): Writing to temp file: {tempFile.FullName}");
                    File.WriteAllLines(tempFile.FullName, csvContents);

                    // Right before we move the temp file to the final destination, let's move the final file to a temporary location
                    // so that we can recover the source file in case we have an error
                    if (finalFile.Exists)
                    {
                        Log.Trace($"BrainDataConverter.WriteToFile[{typeName}](): Moving existing file: {finalFile.FullName} - to temp backup location: {backupFinalFile}");
                        // Use raw File.Move so that we don't lose the final destination in `finalFile`
                        File.Move(finalFile.FullName, backupFinalFile.FullName);
                    }

                    Log.Trace($"BrainDataConverter.WriteToFile[{typeName}](): Moving temp file to: {finalFile.FullName}");
                    tempFile.MoveTo(finalFile.FullName);

                    Log.Trace($"BrainDataConverter.WriteToFile[{typeName}](): Successfully moved temp file to: {finalFile.FullName}");

                    // Just one last check to be absolutely certain we won't be deleting previous data
                    if (finalFile.Exists && backupFinalFile.Exists)
                    {
                        backupFinalFile.Delete();
                        Log.Trace($"BrainDataConverter.WriteToFile[{typeName}](): Deleted backup file");
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e, $"BrainDataConverter.WriteToFile[{typeName}](): Failed to write to file for ticker: {kvp.Key}");

                    if (finalFile.Exists && DateTime.UtcNow.Subtract(finalFile.CreationTime).TotalMinutes >= 1)
                    {
                        Log.Trace($"BrainDataConverter.WriteToFile[{typeName}](): Final file already exists: {finalFile.FullName} - Most likely this is the old file since one minute has passed without modification to the final file");
                        continue;
                    }

                    if (backupFinalFile.Exists && !finalFile.Exists)
                    {
                        Log.Trace($"BrainDataConverter.WriteToFile[{typeName}](): Moving backup final file from: {backupFinalFile.FullName} - to its original location: {finalFile.FullName}");
                        backupFinalFile.MoveTo(finalFile.FullName);
                    }
                }
            }
        }

        /// <summary>
        /// Serializes the instance to a string
        /// </summary>
        /// <typeparam name="T">Type of instance to serialize to string</typeparam>
        /// <param name="instance">Instance object to serialize to string</param>
        /// <returns>serialized data (as string)</returns>
        private string Serialize<T>(T instance)
            where T : BaseData, new()
        {
            if (typeof(T) == typeof(BrainDataSentimentWeekly))
            {
                var castInstance = (BrainDataSentimentWeekly)(BaseData)instance;
                return $"{castInstance.Time:yyyyMMdd HH:mm},{castInstance.Sector},{castInstance.SentimentScore}";
            }
            if (typeof(T) == typeof(BrainDataSentimentMonthly))
            {
                var castInstance = (BrainDataSentimentMonthly)(BaseData)instance;
                return $"{castInstance.Time:yyyyMMdd HH:mm},{castInstance.Sector},{castInstance.SentimentScore}";
            }
            if (typeof(T) == typeof(BrainDataRankingsFiveDay))
            {
                var castInstance = (BrainDataRankingsFiveDay)(BaseData)instance;
                return $"{castInstance.Time:yyyyMMdd HH:mm},{castInstance.RankingScore}";
            }
            if (typeof(T) == typeof(BrainDataRankingsTenDay))
            {
                var castInstance = (BrainDataRankingsTenDay)(BaseData)instance;
                return $"{castInstance.Time:yyyyMMdd HH:mm},{castInstance.RankingScore}";
            }

            throw new NotImplementedException($"Type \"{typeof(T).Name}\" is not supported");
        }
    }
}
