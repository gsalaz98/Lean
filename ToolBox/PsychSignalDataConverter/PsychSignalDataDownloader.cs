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
using System.IO;
using System.Net;
using System.Threading;
using NodaTime;
using QuantConnect.Logging;

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public class PsychSignalDataDownloader
    {
        private readonly string _apiKey;
        private readonly string _dataSource;
        
        /// <summary>
        /// Base URL for the psychsignal API
        /// </summary>
        private readonly string _baseUrl = "https://api.psychsignal.com/v2";

        /// <summary>
        /// Destination we will write raw data to
        /// </summary>
        private readonly string _rawDataDestination;
        
        /// <summary>
        /// Maximum amount of retries per data hour 
        /// </summary>
        public int MaxRetries = 5;
        
        /// <summary>
        /// Downlods data from psychsignal
        /// </summary>
        /// <param name="rawDataDestination">Directory we write raw data to</param>
        /// <param name="apiKey">PsychSignal API key</param>
        /// <param name="dataSource">Data source (e.g. stocktwits,twitter_withretweets)</param>
        public PsychSignalDataDownloader(string rawDataDestination, string apiKey, string dataSource)
        {
            _rawDataDestination = rawDataDestination;

            _dataSource = dataSource;
            _apiKey = apiKey;
        }
        
        /// <summary>
        /// Download the data from the given starting date to the ending date 
        /// </summary>
        /// <param name="startDate">Starting date. This time is should be in Eastern Time</param>
        /// <param name="endDate">Ending date. This time is should be in Eastern Time</param>
        public void Download(DateTime startDate, DateTime endDate)
        {
            if (startDate < DateTime.UtcNow.ConvertFromUtc(TimeZones.NewYork).AddDays(-15))
            {
                throw new ArgumentException("The starting date can only be at most 15 days from now");
            }
            
            Directory.CreateDirectory(_rawDataDestination);
            
            // PsychSignal paginates by hour
            for (; startDate < endDate.ConvertFromUtc(TimeZones.NewYork); startDate = startDate.AddHours(1))
            {
                var rawDataPath = Path.Combine(_rawDataDestination, $"{startDate:yyyyMMdd_HH}_{_dataSource}.csv");
                var rawDataPathTemp = $"{rawDataPath}.tmp";
                
                // Don't download files we already have
                if (File.Exists(rawDataPath))
                {
                    continue;
                }
                
                // Retry in case a download failed
                for (var retries = 0; retries < MaxRetries; retries++)
                {
                    // Psychsignal imposes very strict rate limits
                    Thread.Sleep(7000);

                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile($"{_baseUrl}/replay?apikey={_apiKey}&update=1m&sources={_dataSource}&from={startDate:yyyyMMddHH}&format=csv", rawDataPathTemp);
                            File.Move(rawDataPathTemp, rawDataPath);
                            break;
                        }
                    }
                    catch (WebException e)
                    {
                        var response = (HttpWebResponse) e.Response;

                        if (retries == MaxRetries - 1)
                        {
                            Log.Error($"PsychSignalDataDownloader.Download(): We've reached the maximum number of retries for date {startDate:yyyy-MM-dd HH:00:00}");
                            continue;
                        }
                        if (response == null)
                        {
                            Log.Error("PsychSignalDataDownloader.Download(): Response was null. Retrying...");
                            continue;
                        }
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            Log.Error("PsychSignalDataDownloader.Download(): Server received a bad request. Continuing...");
                            break;
                        }
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            Log.Error("PsychSignalDataDownloader.Download(): Received an HTTP 404. Continuing...");
                            break;
                        }
                        if (response.StatusCode == (HttpStatusCode) 429)
                        {
                            Log.Trace("PsychSignalDataDownloader.Download(): We are being rate limited. Retrying...");
                        }
                        else
                        {
                            Log.Error($"PsychSignalDataDownloader.Download(): Received unknown HTTP status code {(int) response.StatusCode}. Retrying...");
                        }
                    }
                }
            }
        }
    }
}
