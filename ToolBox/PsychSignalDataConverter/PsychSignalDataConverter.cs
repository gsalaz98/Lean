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
using System.IO;
using System.Linq;
using QuantConnect.Logging;
using QuantConnect.Util;

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public class PsychSignalDataConverter
    {
        private readonly Dictionary<string, TickerData> _fileHandles = new Dictionary<string, TickerData>();
        private readonly HashSet<string> _knownTickers;
        private string _previousTicker;
        
        /// <summary>
        /// Raw source directory
        /// </summary>
        public string RawSourceDirectory;

        /// <summary>
        /// Destination directory to write our formatted data
        /// </summary>
        public string DestinationDirectory;

        public PsychSignalDataConverter(string sourceDirectory, string destinationDirectory, string knownTickerFolder)
        {
            RawSourceDirectory = sourceDirectory;
            DestinationDirectory = destinationDirectory;

            _knownTickers = Directory.GetFiles(knownTickerFolder, "*.zip").Select(Path.GetFileNameWithoutExtension).ToHashSet();

            Directory.CreateDirectory(DestinationDirectory);
        }
            
        /// <summary>
        /// Converts a specific file to Lean alternative data format
        /// </summary>
        /// <param name="sourceFilePath"></param>
        public void Convert(string sourceFilePath)
        {
            foreach (var line in File.ReadLines(sourceFilePath))
            {
                ProcessEquity(line);
            }

            // Make sure that we close the final writer so that we write the data and don't get an IOException
            _fileHandles[_previousTicker].Writer.Close();
        }

        /// <summary>
        /// Iterate over the data, processing each data point before finally zipping the directories
        /// </summary>
        public void ConvertDirectory(string sourceDirectory)
        {
            foreach (var rawFile in Directory.GetFiles(RawSourceDirectory, "*.csv", SearchOption.AllDirectories))
            {
                Convert(rawFile);
            }
        }
        
        /// <summary>
        /// Process an equity entry from the psychsignal data
        /// </summary>
        /// <param name="currentLine"></param>
        public void ProcessEquity(string currentLine)
        {
            if (currentLine.StartsWith("SOURCE"))
            {
                return;
            }

            var csv = currentLine.Split(',');

            var ticker = csv[1].ToLower();
            if (!_knownTickers.Contains(ticker))
            {
                return;
            }

            DateTime timestamp;
            if (!DateTime.TryParse(csv[2], out timestamp))
            {
                Log.Error($"Failed to parse timestamp: {csv[2]}");
                return;
            }

            var dataFilePathTemp = Path.Combine(DestinationDirectory, ticker, $"{timestamp:yyyyMMdd}.csv.tmp");
            
            // Avoids having to re-open the file every time we want to write to it
            TickerData fileHandle;
            if (!_fileHandles.TryGetValue(ticker, out fileHandle))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dataFilePathTemp));

                _fileHandles[ticker] = new TickerData(dataFilePathTemp, timestamp.Date);
                fileHandle = _fileHandles[ticker];
            }
            
            // If the day has changed on us, update the writer to the new path
            if (timestamp != fileHandle.Time)
            {
                fileHandle.CloseAndMove();
                _fileHandles[ticker].UpdateWriter(dataFilePathTemp);
            }

            // We need to flush the previous data if our ticker has changed in order to completely write all data to disk.
            // Previously, the last day's data would not be written because the file was never closed. 
            if (_previousTicker != ticker && !string.IsNullOrEmpty(_previousTicker))
            {
                _fileHandles[_previousTicker].CloseAndMove();
                _fileHandles.Remove(_previousTicker);
            }

            // SOURCE[0],SYMBOL[1],TIMESTAMP_UTC[2],BULLISH_INTENSITY[3],BEARISH_INTENSITY[4],BULL_MINUS_BEAR[5],BULL_SCORED_MESSAGES[6],BEAR_SCORED_MESSAGES[7],BULL_BEAR_MSG_RATIO[8],TOTAL_SCANNED_MESSAGES[9]
            fileHandle.Writer.WriteLine(ToCsv(timestamp, csv.Skip(3)));
            _previousTicker = ticker;
        }

        /// <summary>
        /// Converts line of psychsignal data to LEAN's csv format
        /// </summary>
        /// <param name="timestamp">Timestamp as a string to use for filename</param>
        /// <param name="csvData">Data as it comes from data vendor</param>
        /// <returns></returns>
        public string ToCsv(DateTime timestamp, IEnumerable<string> csvData)
        {
            return $"{timestamp.Subtract(new DateTime(timestamp.Year, timestamp.Month, timestamp.Day)).TotalMilliseconds},{string.Join(",", csvData)}";
        }

        private class TickerData
        {
            /// <summary>
            /// File writer as stream
            /// </summary>
            public StreamWriter Writer { get; private set; }

            /// <summary>
            /// Date of the data
            /// </summary>
            public DateTime Time { get; }

            /// <summary>
            /// Path of the current writer
            /// </summary>
            public string DataFilePath;

            /// <summary>
            /// Creates writer instances and saves file path.
            /// Used to keep file open until the path changes for the symbol
            /// </summary>
            /// <param name="dataFilePath">Path to the file we want to write</param>
            public TickerData(string dataFilePath, DateTime day)
            {
                Time = day;
                DataFilePath = dataFilePath;
                Writer = new StreamWriter(dataFilePath);
            }

            public void CloseAndMove()
            {
                Writer.Close();

                // Move temp file to its final path
                File.Move(DataFilePath, Path.GetFileNameWithoutExtension(DataFilePath));
            }

            /// <summary>
            /// Closes and updates the writer to a new file path
            /// </summary>
            /// <param name="dataFilePath">Path to the file we want to write</param>
            public void UpdateWriter(string dataFilePath)
            {
                CloseAndMove();
                Writer = new StreamWriter(dataFilePath);
            }
        }
    }
}
