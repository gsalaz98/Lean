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
using System.Collections.Generic;
using QuantConnect.Data.UniverseSelection;

namespace QuantConnect.Data.Custom.PsychSignal
{
    public class PsychSignalSentimentData : BaseData
    {
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
                    config.Symbol.Value + ".zip"
                ),
                SubscriptionTransportMedium.LocalFile,
                FileFormat.ZipEntryName
            );
        }

        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            return new BaseDataCollection();
        }
    }
}
