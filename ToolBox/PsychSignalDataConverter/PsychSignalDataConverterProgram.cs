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

namespace QuantConnect.ToolBox.PsychSignalDataConverter
{
    public static class PsychSignalDataConverterProgram
    {
        /// <summary>
        /// Entry point for ToolBox application PsychSignalDataDownloader 
        /// </summary>
        /// <param name="startDate">Starting date. Cannot be greater than 15 days from today</param>
        /// <param name="endDate">Ending date</param>
        /// <param name="rawDataDestination">Directory to write raw data to</param>
        /// <param name="apiKey">Psychsignal API key</param>
        /// <param name="dataSource">Psychsignal data source</param>
        public static void PsychSignalDataDownloader(DateTime startDate, DateTime endDate, string rawDataDestination, string apiKey, string dataSource)
        {
            var downloader = new PsychSignalDataDownloader(rawDataDestination, apiKey, dataSource);
            downloader.Download(startDate, endDate);
        }

        /// <summary>
        /// Entry point for ToolBox application PsychSignalDataConverter
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="destinationDirectory"></param>
        /// <param name="knownTickerFolder"></param>
        public static void PsychSignalDataConverter(string sourceDirectory, string destinationDirectory, string knownTickerFolder)
        {
            var converter = new PsychSignalDataConverter(sourceDirectory, destinationDirectory, knownTickerFolder);
            converter.ConvertDirectory();
        }
    }
}
