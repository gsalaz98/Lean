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

using QuantConnect.Configuration;
using QuantConnect.Data;
using QuantConnect.Data.Auxiliary;
using QuantConnect.Interfaces;
using QuantConnect.Logging;
using QuantConnect.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QuantConnect.ToolBox
{
    /// <summary>
    /// Abstract class defines common patterns that are involved in implementing a ToolBox converter
    /// for custom data sources. We provide many generic methods here to ease the amount of boilerplate
    /// code required for each converter.
    ///
    /// If your data source meets the following criteria, you can use this converter's default methods without the need
    /// to overwrite your data:
    ///
    /// 1. Your inherited <see cref="BaseData"/> implementation implements <see cref="IDataConvertable"/>
    /// 2. You are processing data with underlying equity tickers. If you are not, you can override <see cref="MapTicker(string, DateTime, int)"/>
    ///    to return the ticker it was passed in order to disable mapping.
    /// 3. Your data is in the "daily" format. This entails: "yyyyMMdd HH:mm:ss" date values, potentially multiple tickers in
    ///    a single file (due to mapping events), small amounts of data/less than 10GB total size for the entirety of the data source,
    ///    data is keyed by symbol, and you can tolerate non-compressed data
    /// </summary>
    public abstract class ToolBoxDataConverter
    {
        private MapFileResolver _mapFileResolver;

        /// <summary>
        /// Source directory to get raw data from. We provide this variable to make
        /// constructing paths to the source directory easier and cheaper.
        /// </summary>
        public DirectoryInfo SourceDirectory { get; private set; }

        /// <summary>
        /// Destination directory to write files to. This is usually the Data folder.
        /// We provide these variables to make constructing paths to the final destination
        /// easier and cheaper.
        ///
        /// In many cases, the destination directory can contain sub-folders that we
        /// organize data into, such as:
        /// `Globals.DataFolder/alternative/datavendor/sentiment/symbol.csv`
        /// `Globals.DataFolder/alternative/datavendor/messages/symbol.csv`
        /// </summary>
        public DirectoryInfo DestinationDirectory { get; private set; }

        /// <summary>
        /// Intializes the source directory and destination directories.
        /// We also load the corresponding <see cref="IMapFileProvider"/> specified in config.json
        /// </summary>
        /// <param name="sourceDirectory">Source directory of the data. This is the path to the parent directory of the raw data</param>
        /// <param name="destinationDirectory">Destination directory of the data. This is the path to the parent directory of where we want to output the final data</param>
        /// <param name="market">Market we're processing data for</param>
        public ToolBoxDataConverter(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory, string market = Market.USA)
        {
            SourceDirectory = sourceDirectory;
            DestinationDirectory = destinationDirectory;

            _mapFileResolver = Composer.Instance.GetExportedValueByTypeName<IMapFileProvider>(Config.Get("map-file-provider", "LocalDiskMapFileProvider"))
                .Get(market);

            // Create the destination directory so that any operations moving files to it don't fail
            DestinationDirectory.Create();
        }

        /// <summary>
        /// Main entry point for data conversion
        /// </summary>
        /// <returns>Boolean value indicating success or failure</returns>
        public abstract bool Convert(DateTime date);

        /// <summary>
        /// Processes the data into custom data objects
        /// </summary>
        /// <returns>Dictionary keyed by ticker containing enumerable of <see cref="BaseData"/></returns>
        public IEnumerable<T> Process<T>(DateTime date, FileInfo sourceFile)
            where T : BaseData, IDataConvertable, new()
        {
            Log.Trace($"ToolBoxDataConverter.Process[{typeof(T).Name}](): Begin converting {sourceFile.FullName}");

            using (var stream = sourceFile.OpenRead())
            using (var reader = new StreamReader(stream))
            {
                string line;
                var i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    i++;

                    T data;
                    try
                    {
                        // Load the data into an instance of T. Since this operation is prone to failure, we've
                        // wrapped it around a try...catch block so that one line doesn't cause our job to fail
                        data = GetDataInstanceFromRaw<T>(line);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, $"ToolBoxDataConverter.Process[{typeof(T).Name}](): Failed to construct data instance from raw data at line {i}");
                        continue;
                    }

                    // If we can select the date of the instance, use it instead of the date we're processing the file for
                    var selectedDate = data.Time != DateTime.MinValue ? data.Time : date;

                    // In the case that we don't want to use mapping, override `MapTicker` to return the same ticker
                    // that was passed in. Null indicates that we tried to map the symbol, but failed to do so.
                    var mappedSymbol = MapTicker(data.Symbol.Value, selectedDate, i);
                    if (string.IsNullOrEmpty(mappedSymbol))
                    {
                        Log.Trace($"ToolBoxDataConverter.Process[{typeof(T).Name}](): Skipping ticker {data.Symbol.Value} because it resolved to null");
                        continue;
                    }

                    // Make sure we update the mapped symbol so that we can distinguish tickers by mapped symbol
                    data.Symbol = data.Symbol.UpdateMappedSymbol(mappedSymbol);

                    yield return data;
                }
            }
        }

        /// <summary>
        /// Virtual method takes raw data and constructs a new instance of type T with the data loaded into it
        /// </summary>
        /// <typeparam name="T">BaseData type</typeparam>
        /// <param name="line">Line of raw CSV</param>
        /// <returns>New instance of T</returns>
        public virtual T GetDataInstanceFromRaw<T>(string line)
            where T : BaseData, IDataConvertable, new()
        {
            var instance = new T();
            instance.FromRawData(line);

            return instance;
        }

        /// <summary>
        /// Virtual method that instantiates generic type with formatted data loaded into the instance
        /// </summary>
        /// <typeparam name="T">BaseData derived type</typeparam>
        /// <param name="line">Line of formatted CSV in its final form</param>
        /// <returns>New BaseData instance of typeparam T</returns>
        public virtual T GetDataInstance<T>(string line)
            where T : BaseData, IDataConvertable, new()
        {
            var instance = new T();
            instance.FromData(line);

            return instance;
        }

        /// <summary>
        /// Virtual method that serializes to string the given type parameter to a single line
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public virtual string DataInstanceToCsv<T>(T instance)
            where T : BaseData, IDataConvertable
        {
            return instance.ToLine();
        }

        /// <summary>
        /// Overridable method that can be used to implement mapping for tickers
        /// </summary>
        /// <param name="ticker"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual string MapTicker(string ticker, DateTime date, int lineCount)
        {
            var mapFile = _mapFileResolver.ResolveMapFile(ticker, date);
            if (!mapFile.Any())
            {
                Log.Error($"ToolBoxDataConverter.MapTicker(): Failed to get mapfile for ticker {ticker} at line {lineCount} on {date:yyyy-MM-dd}");
                return null;
            }

            var newTicker = mapFile.GetMappedSymbol(date);
            if (string.IsNullOrEmpty(newTicker))
            {
                Log.Error($"ToolBoxDataConverter.MapTicker(): Failed to get mapped symbol for old ticker {ticker} at line {lineCount} on {date:yyyy-MM-dd}");
                return null;
            }
            // This can potentially be a point of failure, so let's log just in case
            if (ticker != newTicker)
            {
                Log.Trace($"ToolBoxDataConverter.MapTicker(): Ticker changed from {ticker} to {newTicker} on {date:yyyy-MM-dd}");
            }

            return newTicker;
        }

        /// <summary>
        /// Writes the data to a file in daily style format
        /// </summary>
        /// <param name="data">Enumerable of data</param>
        public virtual void WriteToFile<T>(IEnumerable<T> data, DirectoryInfo finalDirectory)
            where T : BaseData, IDataConvertable, new()
        {
            // Cache the type name for efficiency
            var typeName = typeof(T).Name;

            foreach (var kvp in data.GroupBy(x => x.Symbol.Value))
            {
                var tempFile = new FileInfo(Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.tmp"));
                var finalFile = new FileInfo(Path.Combine(finalDirectory.FullName, $"{kvp.Key.ToLower()}.csv"));
                var backupFinalFile = new FileInfo(Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.csv"));

                try
                {
                    var finalContents = new List<T>();
                    if (finalFile.Exists)
                    {
                        finalContents = File.ReadAllLines(finalFile.FullName)
                            .Select(x => GetDataInstance<T>(x))
                            .ToList();
                    }

                    finalContents.AddRange(kvp);
                    var csvContents = finalContents.OrderBy(x => x.Time)
                        .Select(x => DataInstanceToCsv(x))
                        .Distinct()
                        .ToList();

                    Log.Trace($"ToolBoxDataConverter.WriteToFile[{typeName}](): Writing to temp file: {tempFile.FullName}");
                    File.WriteAllLines(tempFile.FullName, csvContents);

                    // Right before we move the temp file to the final destination, let's move the final file to a temporary location
                    // so that we can recover the source file in case we have an error
                    if (finalFile.Exists)
                    {
                        Log.Trace($"ToolBoxDataConverter.WriteToFile[{typeName}](): Moving existing file: {finalFile.FullName} - to temp backup location: {backupFinalFile}");
                        // Use raw File.Move so that we don't lose the final destination in `finalFile`
                        File.Move(finalFile.FullName, backupFinalFile.FullName);
                    }

                    Log.Trace($"ToolBoxDataConverter.WriteToFile[{typeName}](): Moving temp file to: {finalFile.FullName}");
                    tempFile.MoveTo(finalFile.FullName);

                    Log.Trace($"ToolBoxDataConverter.WriteToFile[{typeName}](): Successfully moved temp file to: {finalFile.FullName}");

                    // Just one last check to be absolutely certain we won't be deleting previous data
                    if (finalFile.Exists && backupFinalFile.Exists)
                    {
                        backupFinalFile.Delete();
                        Log.Trace($"ToolBoxDataConverter.WriteToFile[{typeName}](): Deleted backup file");
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e, $"ToolBoxDataConverter.WriteToFile[{typeName}](): Failed to write to file for ticker: {kvp.Key}");

                    if (finalFile.Exists && DateTime.UtcNow.Subtract(finalFile.CreationTime).TotalMinutes >= 1)
                    {
                        Log.Trace($"ToolBoxDataConverter.WriteToFile[{typeName}](): Final file already exists: {finalFile.FullName} - Most likely this is the old file since one minute has passed without modification to the final file");
                        continue;
                    }

                    if (backupFinalFile.Exists && !finalFile.Exists)
                    {
                        Log.Trace($"ToolBoxDataConverter.WriteToFile[{typeName}](): Moving backup final file from: {backupFinalFile.FullName} - to its original location: {finalFile.FullName}");
                        backupFinalFile.MoveTo(finalFile.FullName);
                    }
                }
            }
        }
    }
}
