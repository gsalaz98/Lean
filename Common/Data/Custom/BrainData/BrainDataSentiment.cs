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

using QuantConnect.Interfaces;
using System;
using System.Globalization;
using System.IO;

namespace QuantConnect.Data.Custom.BrainData
{
    /// <summary>
    /// Brain Data Sentiment data provides sector information and daily aggregated sentiment data
    /// </summary>
    public class BrainDataSentiment : BaseData, IDataConvertable
    {
        /// <summary>
        /// Industry sector for the given ticker
        /// </summary>
        public string Sector { get; set; }

        /// <summary>
        /// Daily sentiment score for the given stock
        /// </summary>
        public decimal SentimentScore { get; set; }

        /// <summary>
        /// Empty constructor required for <see cref="Slice.Get{T}()"/>
        /// </summary>
        public BrainDataSentiment()
        {
        }

        /// <summary>
        /// Popluates instance properties from formatted CSV data
        /// </summary>
        /// <param name="line">Line of parsed and formatted CSV data</param>
        public void FromData(string line)
        {
            var csv = line.ToCsv(size: 3);

            Time = DateTime.ParseExact(csv[0], "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture);
            Sector = csv[1];
            SentimentScore = Convert.ToDecimal(csv[2], CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Populates instance properties from raw unformatted CSV data
        /// </summary>
        /// <param name="line">Line of raw CSV data</param>
        public void FromRawData(string line)
        {
            var csv = line.ToCsv();

            Time = DateTime.ParseExact(csv[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Symbol = Symbol.Create(csv[1], SecurityType.Base, QuantConnect.Market.USA);
            Sector = csv[2];
            SentimentScore = Convert.ToDecimal(csv[3], CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the data to CSV
        /// </summary>
        /// <returns>CSV formatted data</returns>
        public string ToLine()
        {
            return $"{Time:yyyyMMdd HH:mm:ss},{Sector},{SentimentScore}";
        }

        /// <summary>
        /// Gets the source of the data and directs LEAN where to look for it
        /// </summary>
        /// <param name="config">Subscription configuration</param>
        /// <param name="date">Algorithm date</param>
        /// <param name="isLiveMode">Is live mode</param>
        /// <returns>Location of the data</returns>
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            return new SubscriptionDataSource(
                Path.Combine(
                    Globals.DataFolder,
                    "alternative",
                    "braindata",
                    "sentiment",
                    $"{config.Symbol.Value}.csv"
                ),
                SubscriptionTransportMedium.LocalFile,
                FileFormat.Csv
            );
        }

        /// <summary>
        /// Reads and creates a <see cref="BaseData"/> instance that loads the data onto LEAN
        /// </summary>
        /// <param name="config">Subscription configuration</param>
        /// <param name="line">Line of data</param>
        /// <param name="date">Date of the algorithm</param>
        /// <param name="isLiveMode">Is live mode</param>
        /// <returns>New BaseData instance</returns>
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var instance = new BrainDataSentiment();
            instance.FromData(line);

            return instance;
        }
    }
}
