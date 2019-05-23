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

namespace QuantConnect.Data.Custom.Sec
{
    public class SecReport8K : SecReport
    {
        public SecReport8K(SecReportSubmission report) : base(report)
        {
        }

        /// <summary>
        /// Returns a subscription data source pointing towards SEC 8-K report data
        /// </summary>
        /// <param name="config">User configuration</param>
        /// <param name="date">Date data has been requested for</param>
        /// <param name="isLiveMode">Is livetrading</param>
        /// <returns></returns>
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            // Although our data is stored as a JSON file, we can trick the 
            // SubscriptionDataReader to load our file all at once so long as we store
            // the file in a single line. Then, we can deserialize the whole file in Reader.
            // FineFundamental uses the same technique to read a JSON file.
            return new SubscriptionDataSource(
                Path.Combine(
                    Globals.DataFolder,
                    "equity",
                    QuantConnect.Market.USA,
                    "alternative",
                    "sec",
                    config.Symbol.Value.ToLower(),
                    $"{date:yyyyMMdd}_8K.zip#8K.json"
                ),
                SubscriptionTransportMedium.LocalFile,
                FileFormat.Csv
            );
        }

        /// <summary>
        /// Parses the data into <see cref="BaseData"/>
        /// </summary>
        /// <param name="config">User subscription config</param>
        /// <param name="line">Line of source file to parse</param>
        /// <param name="date">Date data was requested for</param>
        /// <param name="isLiveMode">Is livetrading mode</param>
        /// <returns></returns>
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var report = new SecReport8K(JsonConvert.DeserializeObject<SecReportSubmission>(line));
            report.Time = report.Report.FilingDate;
            report.Symbol = config.Symbol;

            return report;
        }
    }
}