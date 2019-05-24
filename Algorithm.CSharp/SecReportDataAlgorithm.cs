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

using System.Linq;
using QuantConnect.Data;
using QuantConnect.Data.Custom.Sec;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Demonstration algorithm showing how to use and access SEC data
    /// </summary>
    /// <meta name="tag" content="fundamental" />
    /// <meta name="tag" content="custom data" />
    /// <meta name="tag" content="SEC" />
    public class SecReportDataAlgorithm : QCAlgorithm
    {
        private Symbol _symbol;

        public string Ticker = "AAPL";

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetCash(100000);
            SetStartDate(2019, 5, 1);
            SetEndDate(2019, 5, 10);

            _symbol = AddEquity(Ticker, Resolution.Daily).Symbol;
            AddData<SecReport10Q>(Ticker);
        }

        public override void OnData(Slice slice)
        {
            var data = slice.Get<SecReport10Q>();

            // We only want SEC data
            if (!data.ContainsKey(_symbol)) return;

            var report = data[_symbol].Report;

            Log($"Form Type {report.FType}");
            Log($"Filing Date: {report.FilingDate:yyyy-MM-dd}");

            foreach (var filer in report.Filers)
            {
                Log($"Filing company name: {filer.CompanyData.ConformedName}");
                Log($"Filing company CIK: {filer.CompanyData.Cik}");
                Log($"Filing company EIN: {filer.CompanyData.IrsNumber}");

                foreach (var formerCompany in filer.FormerCompanies)
                {
                    Log(
                        $"Former company name of {filer.CompanyData.ConformedName}: {formerCompany.FormerConformedName}"
                    );
                    Log($"Date of company name change: ${formerCompany.Changed:yyyy-MM-dd}");
                }
            }

            // SEC documents can come in multiple documents.
            // For multi-document reports, sometimes the document contents after the first document
            // are files that have a binary format, such as JPG and PDF files
            foreach (var document in report.Documents)
            {
                Log($"Filename: {document.Filename}");
                Log($"Document description: {document.Description}");

                // Print sample of contents contained within the document
                Log(document.Text.Substring(0, 10000));
                Log("=================");
            }
        }
    }
}
