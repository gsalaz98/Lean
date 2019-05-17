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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantConnect.Data;
using QuantConnect.Data.Auxiliary;
using QuantConnect.Logging;

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public class PsychSignalDataConverter
    {
        private Dictionary<Symbol, List<string>> _existingFiles = new Dictionary<Symbol, List<string>>();
        private MapFileResolver _resolver;
        private StreamWriter _writer;
        private Symbol _previousSymbol;
        private string _previousFilename;

        private readonly string _alternativeDataPath;
        private readonly string _market;
        private readonly SecurityType _securityType;

        /// <summary>
        /// Initializes the converter. Does a check to ensure that the alternative data directory exists, otherwise 
        /// </summary>
        /// <param name="alternativeDataPath"></param>
        /// <param name="securityType"></param>
        /// <param name="market"></param>
        public PsychSignalDataConverter(string alternativeDataPath, SecurityType securityType, string market)
        {
            if (!Directory.Exists(alternativeDataPath))
            {
                Log.Error($"Alternative data directory for psychsignal not found. Create the following path and try again: {alternativeDataPath}");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            _alternativeDataPath = alternativeDataPath;
            _securityType = securityType;
            _market = market;
            _resolver = new LocalDiskMapFileProvider().Get(market);
        }

        /// <summary>
        /// Process the data into LEAN format, then write it to disk (append)
        /// </summary>
        /// <param name="data"></param>
        public bool ProcessData(string data)
        {
            var csv = data.Split(',');

            var source = csv[0];
            var ticker = csv[1];

            // A field with the header names exists around lines 1388700-1388900.
            // Screen out by checking for a header value.
            if (source == "SOURCE")
            {
                return true;
            }

            DateTime ts;
            decimal bullIntensity;
            decimal bearIntensity;
            int bullScoredMessages;
            int bearScoredMessages;

            if (!DateTime.TryParse(csv[2], out ts))
            {
                Log.Error($"Failed to parse timestamp: {csv[2]}");
                return false;
            }
            if (!decimal.TryParse(csv[3], out bullIntensity))
            {
                Log.Error($"Failed to parse bull intensity: {csv[3]}");
                return false;
            }
            if (!decimal.TryParse(csv[4], out bearIntensity))
            {
                Log.Error($"Failed to parse bear intensity: {csv[4]}");
                return false;
            }
            if (!int.TryParse(csv[6], out bullScoredMessages))
            {
                Log.Error($"Failed to parse bull scored messages: {csv[6]}");
                return false;
            }
            if(!int.TryParse(csv[7], out bearScoredMessages))
            {
                Log.Error($"Failed to parse bear scored messages: {csv[7]}");
                return false;
            }
            // Screen for: futures, forex, cryptocurrencies, sector names, and non-US exchange symbols
            if (ticker.Contains(".") || ticker.Contains("_") || ticker.Length > 5)
            {
                return true;
            }

            var symbol = Symbol.Create(ticker, _securityType, _market);
            var csvFilename = ts.ToString("yyyyMMdd") + "_" + ticker.ToLower() + ".csv";
            var dataFilePath = Path.Combine(_alternativeDataPath, ticker, csvFilename);

            if (!_existingFiles.ContainsKey(symbol))
            {
                _existingFiles.Add(symbol, new List<string>() {
                    dataFilePath
                });
            }
            else
            {
                _existingFiles[symbol].Add(dataFilePath);
            }
            // Avoids having to re-open the file every time we want to write to it
            if (_previousFilename != csvFilename || _previousSymbol != symbol)
            {
                // Is null on first run
                _writer?.Close();
                _writer = new StreamWriter(dataFilePath, true, Encoding.UTF8, 65536);
            }

            _writer.WriteLine(ToCsv(ts, bullIntensity, bearIntensity, bullScoredMessages, bearScoredMessages));

            _previousSymbol = symbol;
            _previousFilename = csvFilename;

            return true;
        }

        /// <summary>
        /// Converts the data into CSV. A few fields are excluded because we can calculate them ourselves.
        /// The fields removed are: bull_minus_bear, bull_bear_message_ratio
        /// </summary>
        /// <param name="ts">Data timestamp</param>
        /// <param name="bullIntensity">Bull intensity data</param>
        /// <param name="bearIntensity">Bear intensity data</param>
        /// <param name="bullScoredMessages">Bull scored messages data</param>
        /// <param name="bearScoredMessages">Bear scored messages data</param>
        /// <returns>CSV formatted data</returns>
        public string ToCsv(DateTime ts, decimal bullIntensity, decimal bearIntensity, int bullScoredMessages, int bearScoredMessages, int totalScannedMessages)
        {
            var secondsSinceMidnight = ts.Subtract(ts.Date).TotalSeconds;
            return $"{secondsSinceMidnight},{bullIntensity},{bearIntensity},{bullScoredMessages},{bearScoredMessages},{totalScannedMessages}";
        }
    }
}
