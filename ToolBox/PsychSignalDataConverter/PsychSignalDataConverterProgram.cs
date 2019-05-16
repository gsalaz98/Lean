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
using QuantConnect;
using QuantConnect.Logging;

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public static class PsychSignalDataConverterProgram
    {
        public static void PsychSignalDataConverter(string dataAbsolutePath, string securityType, string market)
        {
            if (!File.Exists(dataAbsolutePath))
            {
                Log.Error($"Psychsignal data not found in path {dataAbsolutePath} - Exiting...");
                return;
            }
            
            var alternativeDataFolder = Path.Combine(Globals.DataFolder, securityType, market, "alternative", "psychsignal");

            if (!Directory.Exists(alternativeDataFolder))
            {
                try
                {
                    Directory.CreateDirectory(alternativeDataFolder);
                    Log.Trace($"Created alternative data folder {alternativeDataFolder}");
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    Log.Error($"Failed to create alternative data folder in path: {alternativeDataFolder} - Exiting...");
                    return;
                }
            }

            SecurityType securityTypeLean;

            switch (securityType) {
                case "equity":
                    securityTypeLean = SecurityType.Equity;
                    break;
                case "future":
                    // Not currently supported, but the data contains futures and we might support it in the future
                    securityTypeLean = SecurityType.Future;
                    break;
                default:
                    securityTypeLean = SecurityType.Equity;
                    break;
            }

            var parser = new PsychSignalDataReader(dataAbsolutePath, alternativeDataFolder, securityTypeLean, market);
            parser.ReadData();
        }
    }
}
