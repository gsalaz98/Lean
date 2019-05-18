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

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public static class PsychSignalDataConverter
    {
        /// <summary>
        /// Iterate over the data, processing each data point before finally zipping the directories
        /// </summary>
        public static void Convert(string sourceFilePath, string securityType, string market)
        {
            var tickerFileHandlers = new Dictionary<string, TickerData>();

            var dataFolder = Path.Combine(Globals.DataFolder, securityType, market);
            var sentimentFolder = Path.Combine(dataFolder, "alternative", "psychsignal");
            var knownTickerFolder = Path.Combine(dataFolder, "daily");

            var knownTickers = (from zipFile in Directory.GetFiles(knownTickerFolder, "*.zip")
                               select Path.GetFileNameWithoutExtension(zipFile)).ToList();

            foreach (var ticker in knownTickers)
            {
                Directory.CreateDirectory(Path.Combine(sentimentFolder, ticker));
            }

            foreach (var currentLine in File.ReadLines(sourceFilePath))
            {
                if (currentLine.StartsWith("SOURCE"))
                {
                    continue;
                }

                var csv = currentLine.Split(',');

                var ticker = csv[1].ToLower();
                if (!knownTickers.Contains(ticker))
                {
                    continue;
                }

                DateTime ts;
                if (!DateTime.TryParse(csv[2], out ts))
                {
                    Log.Error($"Failed to parse timestamp: {csv[2]}");
                    continue;
                }

                var tsFormatted = ts.ToString("yyyyMMdd");
                var csvFilename = tsFormatted + ".csv";
                var dataFilePath = Path.Combine(sentimentFolder, ticker, csvFilename);

                // Avoids having to re-open the file every time we want to write to it
                TickerData handler;
                if (!tickerFileHandlers.TryGetValue(ticker, out handler))
                {
                    tickerFileHandlers[ticker] = new TickerData(dataFilePath);
                    handler = tickerFileHandlers[ticker];
                }
                if (handler.DataPath != dataFilePath)
                {
                    tickerFileHandlers[ticker].UpdateWriter(dataFilePath);
                }

                // SOURCE[0],SYMBOL[1],TIMESTAMP_UTC[2],BULLISH_INTENSITY[3],BEARISH_INTENSITY[4],BULL_MINUS_BEAR[5],BULL_SCORED_MESSAGES[6],BEAR_SCORED_MESSAGES[7],BULL_BEAR_MSG_RATIO[8],TOTAL_SCANNED_MESSAGES[9]
                handler.Writer.WriteLine(ToCsv(ts, csv[3], csv[4], csv[6], csv[7], csv[9]));
            }

            foreach (var dataFile in Directory.GetFiles(sentimentFolder, "*.csv", SearchOption.AllDirectories))
            {
                Compression.Zip(dataFile);
            }
        }

        /// <summary>
        /// Converts line of psychsignal data to LEAN's csv format
        /// </summary>
        /// <param name="ts">Timestamp as a string to use for filename</param>
        /// <param name="bullIntensity">Bull intensity</param>
        /// <param name="bearIntensty">Bear intensity</param>
        /// <param name="bullScoredMessages">Bullish message count</param>
        /// <param name="bearScoredMessages">Bearish message count</param>
        /// <param name="totalScoredMessages">Total messages scanned</param>
        /// <returns></returns>
        public static string ToCsv(DateTime ts, string bullIntensity, string bearIntensty, string bullScoredMessages, string bearScoredMessages, string totalScoredMessages)
        {
            return $"{ts.Subtract(new DateTime(ts.Year, ts.Month, ts.Day)).TotalMilliseconds},{bullIntensity},{bearIntensty},{bullScoredMessages},{bearScoredMessages},{totalScoredMessages}";
        }

        private class TickerData
        {
            /// <summary>
            /// File writer as stream
            /// </summary>
            public StreamWriter Writer { get; private set; }

            /// <summary>
            /// Path to the data (csv file)
            /// </summary>
            public string DataPath { get; private set; }

            /// <summary>
            /// Creates writer instances and saves file path.
            /// Used to keep file open until the path changes for the symbol
            /// </summary>
            /// <param name="dataFilePath">Path to the file we want to write</param>
            public TickerData(string dataFilePath)
            {
                DataPath = dataFilePath;
                Writer = new StreamWriter(DataPath);
            }

            /// <summary>
            /// Closes and updates the writer to a new file path
            /// </summary>
            /// <param name="dataFilePath">Path to the file we want to write</param>
            public void UpdateWriter(string dataFilePath)
            {
                DataPath = dataFilePath;
                Writer.Flush();
                Writer.Close();
                Writer = new StreamWriter(DataPath);
            }
        }
    }
}
