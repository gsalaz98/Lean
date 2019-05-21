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
using System;
using System.Collections.Generic;
using System.Text;
using QuantConnect.Logging;

namespace QuantConnect.Data.Custom.Sec
{
    public class SecReport : BaseData
    {
        /// <summary>
        /// String that can be used to access SEC data after May 26, 2000
        /// </summary>
        [JsonProperty("accession_number")]
        public string AccessionNumber;

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("public_document_count")]
        public int PublicDocumentCount;

        /// <summary>
        /// Beginning time the report covers
        /// </summary>
        [JsonProperty("period")]
        public DateTime Period;

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("items")]
        public int Items;

        /// <summary>
        /// Date the report was filed with the SEC
        /// </summary>
        [JsonProperty("filing_date")]
        public DateTime FilingDate;

        /// <summary>
        /// Date the report was last updated to correct an error in the report
        /// </summary>
        [JsonProperty("amend_date")]
        public DateTime? AmendDate = null;

        /// <summary>
        /// CIK number used to identify a company in EDGAR
        /// </summary>
        [JsonProperty("cik")]
        public string Cik;

        /// <summary>
        /// Number used to identify sector
        /// </summary>
        [JsonProperty("assigned_sic")]
        public string AssignedSic;

        /// <summary>
        /// Report type, e.g. 10-Q, 8-K, 10-K
        /// </summary>
        [JsonProperty("form_type")]
        public string FormType;

        /// <summary>
        /// Number assigned by the IRS to the company filing
        /// </summary>
        [JsonProperty("irs_number")]
        public string IrsNumber;

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("fiscal_year_end")]
        public int FiscalYearEnd;

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("act")]
        public string Act;

        /// <summary>
        /// Can be used to access company filings
        /// </summary>
        [JsonProperty("file_number")]
        public string FileNumber;

        /// <summary>
        /// First four digits can be used to access VPRR filings
        /// </summary>
        [JsonProperty("film_number")]
        public string FilmNumber;

        /// <summary>
        /// Name of the file as reported by the SEC
        /// </summary>
        [JsonProperty("filename")]
        public string Filename;
        
        /// <summary>
        /// Raw contents of the SEC report, separated by page number
        /// </summary>
        [JsonProperty("contents")]
        public List<string> Contents;

        /// <summary>
        /// Corrections that are issued past the initial report date
        /// </summary>
        [JsonProperty("corrections")]
        public Dictionary<DateTime, SecReport> Corrections = new Dictionary<DateTime, SecReport>();
        
        /// <summary>
        /// Default ctor
        /// </summary>
        public SecReport() { }

        /// <summary>
        /// SEC report custom data type. ctor parses report contents and updates the instance with
        /// the values found in the report
        /// </summary>
        /// <param name="reportContents">File stream containing report contents</param>
        public SecReport(IEnumerable<string> reportContents)
        {
            var insideTextContents = false;
            var contentBuilder = new StringBuilder();

            foreach (var line in reportContents)
            {
                if (!insideTextContents && line.StartsWith("<"))
                {
                    if (line.StartsWith("<TEXT>"))
                    {
                        insideTextContents = true;
                    }
                    else if (line.StartsWith("<ACCESSION-NUMBER>"))
                    {
                        AccessionNumber = line.Replace("<ACCESSION-NUMBER>", "");
                    }
                    else if (line.StartsWith("<PUBLIC-DOCUMENT-COUNT>"))
                    {
                        PublicDocumentCount = Convert.ToInt32(line.Replace("<PUBLIC-DOCUMENT-COUNT>", ""));
                    }
                    else if (line.StartsWith("<PERIOD>"))
                    {
                        if (!DateTime.TryParse(line.Replace("<PERIOD>", ""), out Period))
                        {
                            Log.Error($"Failed to parse period date from report for CIK {Cik}");
                        }
                    }
                    else if (line.StartsWith("<FILING-DATE>"))
                    {
                        if (!DateTime.TryParse(line.Replace("<FILING-DATE>", ""), out FilingDate))
                        {
                            Log.Error($"Failed to parse period date from report for CIK {Cik}");
                        }
                    }
                    else if (line.StartsWith("<CIK>"))
                    {
                        Cik = line.Replace("<CIK>", "");
                    }
                    else if (line.StartsWith("<ASSIGNED-SIC>"))
                    {
                        AssignedSic = line.Replace("<ASSIGNED-SIC>", "");
                    }
                    else if (line.StartsWith("<IRS-NUMBER>"))
                    {
                        IrsNumber = line.Replace("<IRS-NUMBER>", "");
                    }
                    else if (line.StartsWith("<FISCAL-YEAR-END>"))
                    {
                        FiscalYearEnd = Convert.ToInt32(line.Replace("<FISCAL-YEAR-END>", ""));
                    }
                    else if (line.StartsWith("<FORM-TYPE>") || line.StartsWith("<TYPE>"))
                    {
                        FormType = line.Replace("<FORM-TYPE>", "").Replace("<TYPE>", "");
                    }
                    else if (line.StartsWith("<ACT>"))
                    {
                        Act = line.Replace("<ACT>", "");
                    }
                    else if (line.StartsWith("<FILE-NUMBER>"))
                    {
                        FileNumber = line.Replace("<FILE-NUMBER>", "");
                    }
                    else if (line.StartsWith("<FILM-NUMBER>"))
                    {
                        FilmNumber = line.Replace("<FILM-NUMBER>", "");
                    }
                    else if (line.StartsWith("<FILENAME>"))
                    {
                        Filename = line.Replace("<FILENAME>", "");
                    }
                }
                else if (insideTextContents)
                {
                    if (line.StartsWith("<PAGE>"))
                    {
                        Contents.Add(contentBuilder.ToString());
                        contentBuilder = new StringBuilder();
                    }
                    else if (line.StartsWith("</TEXT>"))
                    {
                        Contents.Add(contentBuilder.ToString());
                        return;
                    }
                    else
                    {
                        contentBuilder.Append(line);
                    }
                }
            }
        }
    }
}
