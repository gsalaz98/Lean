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
        [JsonProperty("PERIOD"), JsonConverter(typeof(SecReportDateTimeConverter))]
        public DateTime Period;
        [JsonProperty("ITEMS"), JsonConverter(typeof(PossibleListConverter<string>))]
        public List<string> Items = new List<string>();
        [JsonProperty("FILING-DATE"), JsonConverter(typeof(SecReportDateTimeConverter))]
        public DateTime FilingDate;
        [JsonProperty("DATE-OF-FILING-CHANGE"), JsonConverter(typeof(SecReportDateTimeConverter))]
        public DateTime FilingDateChange;

        [JsonProperty("FILER"), JsonConverter(typeof(PossibleListConverter<SecReportFiler>))]
        public List<SecReportFiler> Filer = new List<SecReportFiler>();
        [JsonProperty("DOCUMENT"), JsonConverter(typeof(PossibleListConverter<SecReportDocument>))]
        public List<SecReportDocument> Documents = new List<SecReportDocument>();
    }
}