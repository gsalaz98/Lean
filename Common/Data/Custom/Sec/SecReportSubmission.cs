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
using Newtonsoft.Json;

namespace QuantConnect.Data.Custom.Sec
{
    public class SecReportSubmission 
    {
        [JsonProperty("ACCESSION-NUMBER")]
        public string AccessionNumber;
        [JsonProperty("TYPE")]
        public string FType;
        [JsonProperty("PUBLIC-DOCUMENT-COUNT")]
        public string PublicDocumentCount;
        [JsonProperty("PERIOD")]
        public DateTime Period;
        [JsonProperty("ITEMS")]
        public List<string> Items;
        [JsonProperty("FILING-DATE")]
        public DateTime FilingDate;
        [JsonProperty("DATE-OF-FILING-CHANGE")]
        public DateTime FilingDateChange;

        [JsonProperty("FILER")]
        public SecReportFiler Filer;
        [JsonProperty("DOCUMENT")]
        public List<SecReportDocument> Documents;
    }
}