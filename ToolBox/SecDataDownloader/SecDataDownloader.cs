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
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;
using Newtonsoft.Json;
using QuantConnect.Data;
using QuantConnect.Data.Custom.Sec;
using QuantConnect.Logging;
using System.Threading;

namespace QuantConnect.ToolBox.SecDataDownloader
{
    public class SecDataDownloader : IDataDownloader
    {
        /// <summary>
        /// Base URL to query the SEC website for reports
        /// </summary>
        public string BaseUrl = "https://www.sec.gov/Archives/edgar/Feed";
        
        /// <summary>
        /// Number of parallel download jobs we should run.
        /// WARNING: This number should be less than 10 due to SEC request rate limits.
        /// </summary>
        public int ParallelDownloadJobs = 2;

        /// <summary>
        /// Number of parallel processing jobs we should run at the same time.
        /// Avoid setting this number too high because we may run out of memory while
        /// attempting to parse large files.
        /// </summary>
        public int ParallelProcessingJobs = 10;
        
        /// <summary>
        /// Max file size in bytes we're willing to parse. Default is 100Mb
        /// </summary>
        public int MaxFileSize = 100000000;

        /// <summary>
        /// Destination directory for our files
        /// </summary>
        public readonly string Destination = Path.Combine(Globals.DataFolder, "equity", Market.USA, "alternative", "sec");

        /// <summary>
        /// Directory we extract SEC raw data to
        /// </summary>
        public readonly string Source = Path.Combine(Globals.DataFolder, "equity", Market.USA, "alternative", "sec", "raw_data");

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
        public SecDataDownloader(string rawDataPath = null, string rawDataDestination = null)
        {
            Source = rawDataPath ?? Source;
            Destination = rawDataDestination ?? Destination;

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
            if (ParallelDownloadJobs > 10)
            {
                throw new Exception("ParallelDownloadJobs should be less than 10 due to SEC request rate limits.");
            }

            // Limit 32-bit application max potential memory size to avoid memory overflows
            if (IntPtr.Size == 4 && ParallelDownloadJobs * ParallelProcessingJobs * MaxFileSize > 2000000000)
            {
                throw new Exception(
                    "Application is running as a 32bit application, and potential memory overflow can occur. Lower ParallelProcessingJobs or ParallelDownloadJobs and try again"
                );
            }

            Directory.CreateDirectory(Source);

            var dates = new List<DateTime>();
            for (var date = startUtc; date <= endUtc; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            for (var i = 0; i < dates.Count; i += ParallelDownloadJobs)
            {
                Parallel.ForEach(dates.Skip(i).Take(ParallelDownloadJobs), currentDate =>
                    {
                        // SEC does not publish documents on federal US holidays or weekends
                        if (!currentDate.IsCommonBusinessDay() || USHoliday.Dates.Contains(currentDate))
                        {
                            return;
                        }

                        var quarter = currentDate < new DateTime(currentDate.Year, 4, 1) ? "QTR1" :
                            currentDate < new DateTime(currentDate.Year, 7, 1) ? "QTR2" :
                            currentDate < new DateTime(currentDate.Year, 10, 1) ? "QTR3" :
                            "QTR4";

                        var newDataPath = Path.Combine(Source, $"{currentDate:yyyyMMdd}");

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
                        Parallel.ForEach(
                            Directory.GetFiles(newDataPath, "*.nc", SearchOption.AllDirectories).ToList(),
                            new ParallelOptions() { MaxDegreeOfParallelism = ParallelProcessingJobs },
                            rawReportFilePath =>
                            {
                                // Avoid processing files greater than MaxFileSize megabytes
                                if (MaxFileSize < new FileInfo(rawReportFilePath).Length) return;

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
                                            return;
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

                                ISecReport report;
                                try
                                {
                                    report = new SecReportFactory().CreateSecReport(rawReportXmlFilePath);
                                }
                                catch (DataException e)
                                {
                                    Log.Trace(e.Message);
                                    return;
                                }
                                catch (Exception e)
                                {
                                    Log.Error($"XML file path: {rawReportXmlFilePath}");
                                    Log.Error(e.ToString());
                                    return;
                                }

                                var companyCik = report.Report.Filers.First().CompanyData.Cik;

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
                        );

                        Directory.Delete(newDataPath, true);
                    }
                );

                // SEC website only allows a maximum of 10 requests per second.
                // Sleep just to be sure we're not abusing their rate limits.
                Thread.Sleep(1000);
            }

            Directory.Delete(Source, true);

            return new List<BaseData>();
        }

        /// <summary>
        /// Writes the report to disk, where it will be used by LEAN.
        /// If a ticker is not found, the company being reported
        /// will be stored with its CIK value as the ticker.
        /// </summary>
        /// <param name="report">SEC Report object</param>
        /// <param name="ticker">Symbol ticker</param>
        public void WriteReport(ISecReport report, string ticker)
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
