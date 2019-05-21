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
using System.Net;
using ICSharpCode.SharpZipLib.Tar;
using Newtonsoft.Json;
using QuantConnect.Data;
using QuantConnect.Data.Custom.Sec;
using QuantConnect.Logging;

namespace QuantConnect.ToolBox.SecDataDownloader
{
    public class SecDataDownloader : IDataDownloader
    {
        /// <summary>
        /// Base URL to query the SEC website for reports
        /// </summary>
        public string BaseUrl = "https://www.sec.gov/Archives/edgar/Feed";

        /// <summary>
        /// Destination directory for our files
        /// </summary>
        public string Destination = Path.Combine(Globals.DataFolder, "equity", Market.USA, "alternative", "sec");

        /// <summary>
        /// Assets keyed by CIK used to resolve underlying ticker 
        /// </summary>
        public Dictionary<string, string> CikTicker = new Dictionary<string, string>();

        /// <summary>
        /// Supported form types
        /// </summary>
        public List<string> SupportedFormTypes = new List<string>()
        {
            "8-K",
            "10-K",
            "10-Q"
        };

        /// <summary>
        /// Populates the <see cref="CikTicker" /> dictionary with CIK and ticker corresponding to the CIK.
        /// Data is formatted as: CIK,TICKER
        /// </summary>
        /// <param name="cikTickerFilePath">Path to csv file containing tickers and their corresponding CIK values</param>
        public SecDataDownloader(string cikTickerFilePath)
        {
            foreach (var line in File.ReadLines(cikTickerFilePath))
            {
                // CIK[0], TICKER[1]
                var cikSymbol = line.Split(',');

                CikTicker[cikSymbol[0]] = cikSymbol[1];
            }
        }

        public IEnumerable<BaseData> Get(Symbol symbol, Resolution resolution, DateTime startUtc, DateTime endUtc)
        {
            var rawPath = Path.Combine(Destination, "raw");

            Directory.CreateDirectory(rawPath);

            for (var currentDate = startUtc; currentDate <= endUtc; currentDate = currentDate.AddDays(1))
            {
                // SEC does not publish documents on federal US holidays or weekends
                if (!currentDate.IsCommonBusinessDay() || USHoliday.Dates.Contains(currentDate))
                {
                    continue;
                }

                var quarter = currentDate < new DateTime(currentDate.Year, 4, 1) ? "QTR1" :
                    currentDate < new DateTime(currentDate.Year, 7, 1) ? "QTR2" :
                    currentDate < new DateTime(currentDate.Year, 10, 1) ? "QTR3" :
                    "QTR4";

                try
                {
                    using (var client = new WebClient())
                    {
                        var data = client.OpenRead(
                            $"{BaseUrl}/{currentDate.Year}/{quarter}/{currentDate:yyyyMMdd}.nc.tar.gz"
                        );

                        using (var archive = TarArchive.CreateInputTarArchive(data))
                        {
                            var newDataPath = Path.Combine(rawPath, $"{currentDate:yyyyMMdd}");

                            Directory.CreateDirectory(newDataPath);
                            archive.ExtractContents(newDataPath);
                        }
                    }
                }
                catch (WebException)
                {
                    Log.Trace($"Report files not found on date {currentDate:yyyy-MM-dd}");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            // For the meantime, let's only process .nc files, and deal with corrections later
            foreach (var rawReportFilePath in Directory.GetFiles(rawPath, "*.nc", SearchOption.AllDirectories))
            {
                var report = new SecReport(File.ReadLines(rawReportFilePath));

                string ticker;
                if (!CikTicker.TryGetValue(report.Cik, out ticker))
                {
                    continue;
                }
                /*
                 * if (!SupportedFormTypes.Contains(report.FormType))
                 * {
                 *     continue;
                 * }
                 */
                
                WriteReport(report, ticker);
            }

            Directory.Delete(rawPath, true);

            foreach (var dataFolder in Directory.GetDirectories(Destination))
            {
                Compression.ZipDirectory(dataFolder, $"{dataFolder}.zip", false);
                Directory.Delete(dataFolder);
            }

            return new List<BaseData>();
        }

        /// <summary>
        /// Writes the report to disk, where it will be used by LEAN
        /// </summary>
        /// <param name="report">SEC Report object</param>
        /// <param name="ticker">Symbol ticker</param>
        public void WriteReport(SecReport report, string ticker)
        {
            var reportPath = Path.Combine(Destination, ticker.ToLower(), $"{report.FilingDate:yyyyMMdd}");
            var formTypeNormalized = report.FormType.Replace("-", "");
            var reportFilePath = Path.Combine(reportPath, $"{formTypeNormalized}.json");

            Directory.CreateDirectory(reportPath);

            using (var writer = new StreamWriter(reportFilePath))
            {
                writer.Write(JsonConvert.SerializeObject(report, Formatting.None));
            }
        }
    }
}
