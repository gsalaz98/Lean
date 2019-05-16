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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public class PsychSignalDataConverter
    {
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        public void ProcessData(string data)
        {
            var csv = data.Split(',');

            var source = csv[0];
            var symbol = csv[1];

            DateTime ts;
            decimal bullIntensity;
            decimal bearIntensity;
            decimal bullMinusBear;
            int bullScoredMessages;
            int bearScoredMessages;
            decimal bullBearMessageRatio;
            int totalScannedMessages;

            if (!DateTime.TryParse(csv[2], out ts))
            {
                throw new Exception("Failed to parse timestamp");
            }
            if (!decimal.TryParse(csv[3], out bullIntensity))
            {
                throw new Exception("Failed to parse bull intensity");
            }
            if (!decimal.TryParse(csv[4], out bearIntensity))
            {
                throw new Exception("Failed to parse bear intensity");
            }
            if (!decimal.TryParse(csv[5], out bullMinusBear))
            {
                throw new Exception("Failed to parse bull minus bear intensity");
            }
            if (!int.TryParse(csv[6], out bullScoredMessages))
            {
                throw new Exception("Failed to parse bull scored messages");
            }
            if(!int.TryParse(csv[7], out bearScoredMessages))
            {
                throw new Exception("Failed to parse bear scored messages");
            }
            if (!decimal.TryParse(csv[8], out bullBearMessageRatio))
            {
                throw new Exception("Failed to parse bull bear message ratio");
            }
            if (!int.TryParse(csv[9], out totalScannedMessages))
            {
                throw new Exception("Failed to parse total scanned messages");
            }
        }   
    }
}
