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
 *
*/

using System;
using System.IO;

namespace QuantConnect.Data.Custom.PsychSignal
{
    public class PsychSignalSentimentData : BaseData
    {
        /// <summary>
        /// Bullish intensity as reported by psychsignal
        /// </summary>
        public decimal BullIntensity { get; private set; }

        /// <summary>
        /// Bearish intensity as reported by psychsignal
        /// </summary>
        public decimal BearIntensity { get; private set; }
        
        /// <summary>
        /// Bullish intensity minus bearish intensity
        /// </summary>
        public decimal BullMinusBear { get; private set; }

        /// <summary>
        /// Total bullish scored messages
        /// </summary>
        public int BullScoredMessages { get; private set; }

        /// <summary>
        /// Total bearish scored messages
        /// </summary>
        public int BearScoredMessages { get; private set; }
        
        /// <summary>
        /// Bull/Bear message ratio.
        /// </summary>
        /// <remarks>If bearish messages equals zero, then the resulting value equals zero</remarks>
        public decimal BullBearMessageRatio { get; private set; }

        /// <summary>
        /// Total messages scanned.
        /// </summary>
        /// <remarks>
        /// Sometimes, there will be no bull/bear rated messages, but nonetheless had messages scanned.
        /// This field describes the total fields that were scanned in a minute
        /// </remarks>
        public int TotalScoredMessages { get; private set; }

        /// <summary>
        /// Retrieve Psychsignal data from disk and return it to user's custom data subscription
        /// </summary>
        /// <param name="config">Configuration</param>
        /// <param name="date">Date of this source file</param>
        /// <param name="isLiveMode">true if we're in livemode, false for backtesting mode</param>
        /// <returns></returns>
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            return new SubscriptionDataSource(
                Path.Combine(
                    Globals.DataFolder,
                    "equity",
                    config.Market,
                    "alternative",
                    "psychsignal",
                    config.Symbol.Value.ToLower(),
                    date.ToString("yyyyMMdd") + ".zip"
                ),
                SubscriptionTransportMedium.LocalFile,
                FileFormat.Csv
            );
        }

        /// <summary>
        ///     Reader converts each line of the data source into BaseData objects. Each data type creates its own factory method,
        ///     and returns a new instance of the object
        ///     each time it is called. The returned object is assumed to be time stamped in the config.ExchangeTimeZone.
        /// </summary>
        /// <param name="config">Subscription data config setup object</param>
        /// <param name="line">Line of the source document</param>
        /// <param name="date">Date of the requested data</param>
        /// <param name="isLiveMode">true if we're in live mode, false for backtesting mode</param>
        /// <returns>
        ///     Instance of the T:BaseData object generated by this line of the CSV
        /// </returns> 
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var csv = line.Split(',');

            var ts = new DateTime(date.Year, date.Month, date.Day).AddMilliseconds(Convert.ToDouble(csv[0]));
            var bullIntensity = Convert.ToDecimal(csv[1]);
            var bearIntensity = Convert.ToDecimal(csv[2]);
            var bullMinusBear = bullIntensity - bearIntensity;
            var bullScoredMessages = Convert.ToInt32(csv[3]);
            var bearScoredMessages = Convert.ToInt32(csv[4]);
            var totalScoredMessages = Convert.ToInt32(csv[5]);

            return new PsychSignalSentimentData()
            {
                Time = ts,
                Symbol = config.Symbol,
                Value = bullMinusBear,
                BullIntensity = bullIntensity,
                BearIntensity = bearIntensity,
                BullMinusBear = bullMinusBear,
                BullScoredMessages = bullScoredMessages,
                BearScoredMessages = bearScoredMessages,
                BullBearMessageRatio = bearScoredMessages == 0 ? 0 : bullScoredMessages / bearScoredMessages,
                TotalScoredMessages = totalScoredMessages
            };
        }
    }
}
