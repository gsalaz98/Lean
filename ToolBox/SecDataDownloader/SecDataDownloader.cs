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
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;
using Newtonsoft.Json;
using QuantConnect.Data;
using QuantConnect.Data.Custom.Sec;
using QuantConnect.Logging;
using System.Data;

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
        public Dictionary<string, List<string>> CikTicker = new Dictionary<string, List<string>>();

        /// <summary>
        /// List of known equities taken from the daily data folder
        /// </summary>
        public List<string> KnownEquities;

        /// <summary>
        /// Populates the <see cref="CikTicker" /> dictionary with CIK and ticker corresponding to the CIK.
        /// Data is formatted as: Ticker\tCIK. Data is retrieved from SEC website.
        /// </summary>
        public SecDataDownloader()
        {
            using (var client = new WebClient())
            {
                var knownTickerFolder = Path.Combine(Globals.DataFolder, "equity", "usa", "daily");
                var data = client.DownloadString("https://www.sec.gov/include/ticker.txt");

                data.Split('\n')
                    .Select(x => x.Split('\t'))
                    .ToList()
                    .ForEach(
                        tickerCik =>
                        {
                            var cikFormatted = tickerCik[1].PadLeft(10, '0');

                            if (!CikTicker.ContainsKey(cikFormatted))
                            {
                                CikTicker[cikFormatted] = new List<string>();
                            }

                            CikTicker[cikFormatted].Add(tickerCik[0]);
                        });

                KnownEquities = Directory.GetFiles(knownTickerFolder)
                    .Select(x => Path.GetFileNameWithoutExtension(x).ToLower())
                    .ToList();
            }
        }

        public IEnumerable<BaseData> Get(Symbol symbol, Resolution resolution, DateTime startUtc, DateTime endUtc)
        {
            var rawPath = Path.Combine(Destination, "raw_data");

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

                var newDataPath = Path.Combine(rawPath, $"{currentDate:yyyyMMdd}"); ;

                try
                {
                    using (var client = new WebClient())
                    {
                        using (var data = client.OpenRead(
                            $"{BaseUrl}/{currentDate.Year}/{quarter}/{currentDate:yyyyMMdd}.nc.tar.gz"
                        ))
                        {
                            using (var archive = TarArchive.CreateInputTarArchive(new GZipInputStream(data)))
                            {
                                Directory.CreateDirectory(newDataPath);
                                archive.ExtractContents(newDataPath);

                                Log.Trace($"Extracted SEC data to path {newDataPath}");
                            }
                        }
                    }
                }
                catch (WebException)
                {
                    Log.Error($"Report files not found on date {currentDate:yyyy-MM-dd}");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }

                // For the meantime, let's only process .nc files, and deal with corrections later.
                foreach (var rawReportFilePath in Directory.GetFiles(newDataPath, "*.nc", SearchOption.AllDirectories))
                {
                    var rawReportXmlFilePath = $"{rawReportFilePath}.xml";
                    var factory = new SecReportFactory();

                    using (var writer = new StreamWriter(rawReportXmlFilePath))
                    {
                        // We need to escape any nested XML to ensure our deserialization happens smoothly
                        var parsingText = false;

                        foreach (var line in File.ReadLines(rawReportFilePath))
                        {
                            var newTextLine = line;
                            var currentTagName = factory.GetTagNameFromLine(line);

                            // This tag is present rarely in SEC reports, but is unclosed when encountered.
                            // Verified by searching with ripgrep for "CONFIRMING-COPY"
                            if (currentTagName == "CONFIRMING-COPY")
                            {
                                continue;
                            }

                            // Don't encode the closing tag
                            if (currentTagName == "/TEXT")
                            {
                                parsingText = false;
                            }

                            // Encode all contents inside tags to prevent errors in XML parsing.
                            // The json deserializer will convert these values back to their original form
                            if (!parsingText && factory.HasValue(line))
                            {
                                newTextLine =
                                    $"<{currentTagName}>{SecurityElement.Escape(factory.GetTagValueFromLine(line))}</{currentTagName}>";
                            }
                            // Escape all contents inside TEXT tags
                            else if (parsingText)
                            {
                                newTextLine = SecurityElement.Escape(line);
                            }

                            // Don't encode the opening tag
                            if (currentTagName == "TEXT")
                            {
                                parsingText = true;
                            }

                            writer.WriteLine(newTextLine);
                        }
                    }

                    SecReport report;
                    try
                    {
                        report = new SecReportFactory().CreateSecReport(rawReportXmlFilePath);
                    }
                    catch (DataException e)
                    {
                        Log.Trace(e.Message);
                        continue;
                    }
                    catch (Exception e)
                    {
                        Log.Error($"XML file path: {rawReportXmlFilePath}");
                        Log.Error(e.ToString());
                        continue;
                    }

                    var companyCik = report.Report.Filer.First().CompanyData.Cik;

                    List<string> tickers;
                    if (!CikTicker.TryGetValue(companyCik, out tickers))
                    {
                        tickers = new List<string>();
                    }

                    // Default to company CIK if no known ticker is found
                    var ticker = tickers.Where(secTicker => KnownEquities.Contains(secTicker))
                        .DefaultIfEmpty(companyCik)
                        .First();

                    WriteReport(report, ticker);
                    File.Delete(rawReportFilePath);
                    File.Delete(rawReportXmlFilePath);
                }

                Directory.Delete(newDataPath, true);
            }

            Directory.Delete(rawPath, true);

            return new List<BaseData>();
        }

        /// <summary>
        /// Writes the report to disk, where it will be used by LEAN.
        /// If a ticker is not found, the company being reported
        /// will be stored with its CIK value as the ticker.
        /// </summary>
        /// <param name="report">SEC Report object</param>
        /// <param name="ticker">Symbol ticker</param>
        public void WriteReport(SecReport report, string ticker)
        {
            var reportPath = Path.Combine(Destination, ticker.ToLower(), $"{report.Report.FilingDate:yyyyMMdd}");
            var formTypeNormalized = report.Report.FType.Replace("-", "");
            var reportFilePath = $"{reportPath}_{formTypeNormalized}";

            Directory.CreateDirectory(reportFilePath);

            using (var writer = new StreamWriter(Path.Combine(reportFilePath, $"{formTypeNormalized}.json")))
            {
                writer.Write(JsonConvert.SerializeObject(report.Report, Formatting.None));
            }

            Compression.ZipDirectory(reportFilePath, $"{reportFilePath}.zip", false);
            Directory.Delete(reportFilePath, true);
        }
    }
}
