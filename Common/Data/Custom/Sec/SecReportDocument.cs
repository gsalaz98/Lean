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

using Newtonsoft.Json;

namespace QuantConnect.Data.Custom.Sec
{
    public class SecReportDocument
    {
        /// <summary>
        /// Report document type, e.g. 10-Q, 8-K, S-1
        /// </summary>
        [JsonProperty("TYPE")]
        public string FType;

        /// <summary>
        /// Nth attachment to the form filed
        /// </summary>
        [JsonProperty("SEQUENCE")]
        public int Sequence;

        /// <summary>
        /// File name that the file had when it was uploaded
        /// </summary>
        [JsonProperty("FILENAME")]
        public string Filename;

        /// <summary>
        /// Describes attachment contents
        /// </summary>
        [JsonProperty("DESCRIPTION")]
        public string Description;

        /// <summary>
        /// Contents of the attachment
        /// </summary>
        [JsonProperty("TEXT")]
        public string Text;
    }
}