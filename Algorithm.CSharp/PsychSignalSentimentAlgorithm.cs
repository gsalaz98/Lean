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

using QuantConnect.Data;
using QuantConnect.Data.Custom.PsychSignal;
using QuantConnect.Indicators;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// This example algorithm shows how to import and use psychsignal sentiment data.
    /// </summary>
    /// <meta name="tag" content="strategy example" />
    /// <meta name="tag" content="using data" />
    /// <meta name="tag" content="custom data" />
    /// <meta name="tag" content="psychsignal" />
    /// <meta name="tag" content="sentiment" />
    public class PsychSignalSentimentAlgorithm : QCAlgorithm
    {
        private const string Ticker = "AAPL";
        private Symbol _symbol;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2011, 1, 1);
            SetEndDate(2012, 12, 31);
            SetCash(100000);

            _symbol = AddData<PsychSignalSentimentData>(Ticker, Resolution.Daily).Symbol;
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="slice">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice slice)
        {
            Log(":wave:");
            var sentimentData = slice.Get<PsychSignalSentimentData>();
            foreach (var row in sentimentData.Values)
            {
                Log($"{Time} - {row.Symbol.Value} - BullIntensity: {row.BullIntensity}, BearIntensity: {row.BearIntensity}, BullMinusBear: {row.Value}, BullMessages: {row.BullScoredMessages}, BearMessages: {row.BearScoredMessages}, BullBearMsgRatio: {row.BullBearMessageRatio}, TotalMessages{row.TotalScoredMessages}");

                if (Portfolio.Invested && row.BearIntensity < -2.0m && row.BearScoredMessages >= 3)
                {
                    MarketOrder(_symbol, -Portfolio[_symbol].Quantity);
                }
                else if (!Portfolio.Invested && row.BullIntensity > 2.0m && row.BullScoredMessages >= 3)
                {
                    MarketOrder(_symbol, CalculateOrderQuantity(_symbol, 0.10));
                }
            }
        }
    }
}
