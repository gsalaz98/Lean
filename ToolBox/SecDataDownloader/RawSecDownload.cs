

using System;
using System.IO;
using System.Net;
using System.Threading;
using QuantConnect.Logging;

namespace QuantConnect.ToolBox.SecDataDownloader
{
    public class RawSecDownload
    {
        /// <summary>
        /// Base URL to query the SEC website for reports
        /// </summary>
        public string BaseUrl = "https://www.sec.gov/Archives/edgar";

        /// <summary>
        /// Maximum retries to request SEC edgar filings. Used in <see cref="GetReportPublicationTimes"/>
        /// </summary>
        public int MaxRetries = 5;

        public void Download(string rawDestination, DateTime start, DateTime end) 
        {
            Directory.CreateDirectory(rawDestination);

            for (var currentDate = start; currentDate <= end; currentDate = currentDate.AddDays(1))
            {
                // SEC does not publish documents on US federal holidays or weekends
                if (!currentDate.IsCommonBusinessDay() || USHoliday.Dates.Contains(currentDate))
                {
                    continue;
                }

                var quarter = currentDate < new DateTime(currentDate.Year, 4, 1) ? "QTR1" :
                    currentDate < new DateTime(currentDate.Year, 7, 1) ? "QTR2" :
                    currentDate < new DateTime(currentDate.Year, 10, 1) ? "QTR3" :
                    "QTR4";

                var rawFile = Path.Combine(rawDestination, $"{currentDate:yyyyMMdd}.nc.tar.gz");
                var tmpFile = Path.Combine(rawDestination, $"{currentDate:yyyyMMdd}.nc.tar.gz.tmp");

                if (File.Exists(rawFile))
                {
                    continue;
                }

                for (var retries = 0; retries < MaxRetries; retries++)
                {
                    Thread.Sleep(1000);
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile($"{BaseUrl}/Feed/{currentDate.Year}/{quarter}/{currentDate:yyyyMMdd}.nc.tar.gz", tmpFile);
                            File.Move(tmpFile, rawFile);
                            Log.Trace($"RawSecDownload.Download(): Successfully downloaded {currentDate:yyyyMMdd}.nc.tar.gz");
                            break;
                        }
                    }
                    catch (WebException e)
                    {
                        var response = (HttpWebResponse) e.Response;

                        if (response.StatusCode == HttpStatusCode.Forbidden)
                        {
                            Log.Error($"RawSecDownload.Download(): Report files not found on date {currentDate:yyyy-MM-dd}");
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }
        }
    }
}
