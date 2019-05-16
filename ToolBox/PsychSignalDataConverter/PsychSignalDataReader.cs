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
    public class PsychSignalDataReader
    {
        private int _chunkSize;
        private int _currentChunk;
        private StreamReader _reader;
        private List<string> _currentData = new List<string>();
        private PsychSignalDataConverter _converter; 

        /// <summary>
        /// Processes and reads psychsignal data in chunks to avoid
        /// running out of memory.
        /// 
        /// Chunksize is set to a default of 100000, but can be changed
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="chunkSize"></param>
        public PsychSignalDataReader(string filePath, string alternativeDataFolder, SecurityType securityType = SecurityType.Equity, string market = "usa", int chunkSize = 100000)
        {
            _reader = new StreamReader(filePath);
            _chunkSize = chunkSize;
            _converter = new PsychSignalDataConverter(alternativeDataFolder, securityType, market);
        }

        public void ReadData()
        {
            var header = _reader.ReadLine();
            var currentLine = _reader.ReadLine();

            Log.Trace(header);
            Log.Trace(currentLine);

            while (currentLine != string.Empty && currentLine != null)
            {
                var successful = _converter.ProcessData(currentLine);

                if (!successful)
                {
                    Log.Trace($"Failed at line: {_currentChunk}");
                    return;
                }

                currentLine = _reader.ReadLine();
                _currentChunk++;
            }
        }
    }
}
