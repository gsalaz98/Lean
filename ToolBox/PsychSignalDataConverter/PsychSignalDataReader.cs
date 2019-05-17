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
using System.Threading.Tasks;
using QuantConnect.Logging;
using FileHandleCollection = System.Collections.Generic.Dictionary<System.DateTime, string>;

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public class PsychSignalDataReader
    {
        private List<string> _currentData = new List<string>();
        private PsychSignalDataConverter _converter; 

        /// <summary>
        /// Processes and converts psychsignal data into a format suitable for use by Lean
        /// </summary>
        public PsychSignalDataReader()
        {
        }

        /// <summary>
        /// Iterate over the data, processing each data point before finally zipping the directories
        /// </summary>
        public void Convert(string alternativeDataPath)
        {
            var previousFileName = string.Empty;
            var previousTicker = string.Empty;
            StreamWriter writer = null;

            foreach (var currentLine in File.ReadLines(alternativeDataPath))
            {
                if (currentLine.StartsWith("SOURCE"))
                {
                    continue;
                }

                var csv = currentLine.Split(',');

                var source = csv[0];
                var ticker = csv[1];

                DateTime ts;

                if (!DateTime.TryParse(csv[2], out ts))
                {
                    Log.Error($"Failed to parse timestamp: {csv[2]}");
                    continue;
                }

                var tsFormatted = ts.ToString("yyyyMMdd");
                var csvFilename = tsFormatted + ".csv";
                var dataFilePath = Path.Combine(alternativeDataPath, ticker, csvFilename);

                // Avoids having to re-open the file every time we want to write to it
                if (previousFileName != csvFilename || previousTicker != ticker)
                {
                    // Is null on first run
                    writer?.Close();
                    writer = new StreamWriter(dataFilePath, true, Encoding.UTF8, 65536);
                }

                writer.WriteLine(PsychSignalDataReader.ToCsv(ts, csv[2], csv[3], csv[4], csv[5], csv[8]));

                _previousSymbol = symbol;
                _previousFilename = csvFilename;

                return true
            }
            _converter.MoveAndCompress();
        }

        public static string ToCsv(string ts, string bullIntensity, string bearIntensty, string bullScoredMessages, string bearScoredMessages, string totalScoredMessages)
        {
                return $"{ts},{bullIntensity},{bearIntensty},{bullScoredMessages},{bearScoredMessages},{totalScoredMessages}";
        }
    }
}
