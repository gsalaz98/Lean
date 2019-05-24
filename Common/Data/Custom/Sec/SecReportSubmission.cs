﻿/*
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
        /// <summary>
        /// Number used to access document filings on the SEC website
        /// </summary>
        [JsonProperty("ACCESSION-NUMBER")]
        public string AccessionNumber;

        /// <summary>
        /// SEC form type
        /// </summary>
        [JsonProperty("TYPE")]
        public string FType;

        /// <summary>
        /// Number of documents made public by the SEC
        /// </summary>
        [JsonProperty("PUBLIC-DOCUMENT-COUNT")]
        public string PublicDocumentCount;

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("PERIOD"), JsonConverter(typeof(SecReportDateTimeConverter))]
        public DateTime Period;

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("ITEMS"), JsonConverter(typeof(PossibleListConverter<string>))]
        public List<string> Items = new List<string>();

        /// <summary>
        /// Date report was filed with the SEC
        /// </summary>
        [JsonProperty("FILING-DATE"), JsonConverter(typeof(SecReportDateTimeConverter))]
        public DateTime FilingDate;

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("DATE-OF-FILING-CHANGE"), JsonConverter(typeof(SecReportDateTimeConverter))]
        public DateTime FilingDateChange;
        
        /// <summary>
        /// Contains information regarding who the filer of the report is
        /// </summary>
        [JsonProperty("FILER"), JsonConverter(typeof(PossibleListConverter<SecReportFiler>))]
        public List<SecReportFiler> Filers = new List<SecReportFiler>();

        /// <summary>
        /// Attachments/content associated with the report
        /// </summary>
        [JsonProperty("DOCUMENT"), JsonConverter(typeof(PossibleListConverter<SecReportDocument>))]
        public List<SecReportDocument> Documents = new List<SecReportDocument>();
    }
}