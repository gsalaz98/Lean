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
using QuantConnect.Logging;
using QuantConnect.Util;

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public class PsychSignalDataConverter
    {
        private readonly Dictionary<string, TickerData> _fileHandles;
        private readonly HashSet<string> _knownTickers;
        private readonly DirectoryInfo _rawSourceDirectory;
        private readonly DirectoryInfo _destinationDirectory;
        private string _previousTicker;

        /// <summary>
        /// Converts psychsignal raw data into a format usable by Lean
        /// </summary>
        /// <param name="sourceDirectory">Directory to source our raw data from</param>
        /// <param name="destinationDirectory">Directory to write formatted data to</param>
        /// <param name="knownTickerFolder">Directory where we source the ticker list</param>
        public PsychSignalDataConverter(string sourceDirectory, string destinationDirectory, string knownTickerFolder)
        {
            _rawSourceDirectory = new DirectoryInfo(sourceDirectory);
            _destinationDirectory = new DirectoryInfo(destinationDirectory);

            _fileHandles = new Dictionary<string, TickerData>();
            _knownTickers = Directory.GetFiles(knownTickerFolder, "*.zip").Select(Path.GetFileNameWithoutExtension).ToHashSet();

            _destinationDirectory.Create();
        }
        
        /// <summary>
        /// Converts a specific file to Lean alternative data format
        /// </summary>
        /// <param name="sourceFilePath">File to process and convert</param>
        public void Convert(FileInfo sourceFilePath)
        {
            var file = File.ReadLines(sourceFilePath.FullName);
            var totalLines = file.Count();
            var lineCount = 0;

            foreach (var line in file)
            {
                lineCount++;

                var csv = line.Split(',');
                var ticker = csv[1].ToLower();
                DateTime timestamp;

                if (csv[0] == "SOURCE" || !_knownTickers.Contains(ticker) || !DateTime.TryParseExact(csv[2], @"yyyy-MM-dd\THH:mm:ss\Z", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out timestamp))
                {
                    continue;
                }

                TickerData handle;
                if (!_fileHandles.TryGetValue(ticker, out handle))
                {
                    handle = new TickerData(ticker, timestamp.Date, _destinationDirectory);
                    _fileHandles[ticker] = handle;
                }
                
                // When the ticker changes to another one, it's time to attempt disposal of the previous writer
                if (_previousTicker != ticker && !string.IsNullOrEmpty(_previousTicker))
                {
                    var previousHandle = _fileHandles[_previousTicker];

                    previousHandle.Dispose();
                    previousHandle.MoveTempFile();
                }
                
                handle.Append(timestamp, csv);

                // Writes the final ticker's data if we've reached the end of the file and another file doesn't exist after the current
                if (lineCount == totalLines)
                {
                    var hasNextFile = _rawSourceDirectory
                        .GetFiles("*.csv", SearchOption.TopDirectoryOnly)
                        .Any(x => x.Name.StartsWith($"{timestamp.AddHours(1):yyyyMMdd_HH}"));

                    if (!hasNextFile)
                    {
                        handle.Dispose();
                        handle.MoveTempFile();
                    }
                }

                _previousTicker = ticker;
            }
        }

        /// <summary>
        /// Iterate over the data, processing each data point before finally zipping the directories
        /// </summary>
        public void ConvertDirectory()
        {
            foreach (var rawFile in _rawSourceDirectory.GetFiles("*.csv", SearchOption.AllDirectories))
            {
                Convert(rawFile);
            }
        }
        
        private class TickerData : IDisposable
        {
            private StreamWriter _writer;
            private readonly string _ticker;
            private readonly DirectoryInfo _destinationDirectory;
            private string _tempPath;
            private DateTime _date;

            /// <summary>
            /// Creates writer instances and saves file path.
            /// Used to keep file open until the path changes for the symbol
            /// </summary>
            /// <param name="ticker"></param>
            /// <param name="date"></param>
            /// <param name="destinationDirectory"></param>
            public TickerData(string ticker, DateTime date, DirectoryInfo destinationDirectory)
            {
                _date = date;
                _ticker = ticker;
                _tempPath = Path.GetTempFileName();
                _writer = new StreamWriter(_tempPath);
                _destinationDirectory = destinationDirectory;
            }
            
            /// <summary>
            /// Adds a new line to the writer
            /// </summary>
            /// <param name="timestamp">Event timestamp in UTC</param>
            /// <param name="csv">CSV enumerable</param>
            public void Append(DateTime timestamp, IEnumerable<string> csv)
            {
                var date = timestamp.Date;

                if (date != _date)
                {
                    Dispose();
                    MoveTempFile();

                    _date = date;
                    _tempPath = Path.GetTempFileName();
                    _writer = new StreamWriter(_tempPath);
                }

                _writer.WriteLine(ToCsv(timestamp, csv.Skip(3)));
            }
            
            /// <summary>
            /// Moves the temporary file containing data to the final path, deleting
            /// any existing file to avoid conflicts when moving
            /// </summary>
            public void MoveTempFile()
            {
                var tickerDirectory = Path.Combine(_destinationDirectory.FullName, _ticker);
                var writePath = Path.Combine(tickerDirectory, $"{_date:yyyyMMdd}.csv");

                Directory.CreateDirectory(tickerDirectory);

                // Have only the latest version of the data
                if (File.Exists(writePath))
                {
                    File.Delete(writePath);
                }

                File.Move(_tempPath, writePath);
                Log.Trace($"PsychSignalDataConverter.TickerData.MoveTempFile(): Finished writing file: {Path.Combine(_destinationDirectory.FullName, _ticker, $"{_date:yyyyMMdd}.csv")}");
            }

            /// <summary>
            /// Converts line of psychsignal data to LEAN's csv format
            /// </summary>
            /// <param name="timestamp">Timestamp as a string to use for filename</param>
            /// <param name="csvData">Data as it comes from data vendor</param>
            /// <returns>CSV formatted string</returns>
            private string ToCsv(DateTime timestamp, IEnumerable<string> csvData)
            {
                // SOURCE[0],SYMBOL[1],TIMESTAMP_UTC[2],BULLISH_INTENSITY[3],BEARISH_INTENSITY[4],BULL_MINUS_BEAR[5],BULL_SCORED_MESSAGES[6],BEAR_SCORED_MESSAGES[7],BULL_BEAR_MSG_RATIO[8],TOTAL_SCANNED_MESSAGES[9]
                return $"{timestamp.TimeOfDay.TotalMilliseconds},{string.Join(",", csvData)}";
            }
            
            /// <summary>
            /// Flushes and closes the underlying <see cref="StreamWriter"/>
            /// </summary>
            public void Dispose()
            {
                _writer.Flush();
                _writer.Close();
            }
        }
    }
}
