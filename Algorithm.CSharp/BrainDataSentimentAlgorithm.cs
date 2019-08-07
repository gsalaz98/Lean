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
using QuantConnect.Data.Custom.BrainData;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// This example algorithm shows how to import and use braindata averaged sentiment data.
    /// </summary>
    /// <meta name="tag" content="strategy example" />
    /// <meta name="tag" content="using data" />
    /// <meta name="tag" content="custom data" />
    /// <meta name="tag" content="alternative data" />
    /// <meta name="tag" content="braindata" />
    /// <meta name="tag" content="sentiment" />
    public class BrainDataSentimentAlgorithm : QCAlgorithm
    {
        private Symbol _equitySymbol;
        private Symbol _weeklySymbol;
        private Symbol _monthlySymbol;
        private readonly string _ticker = "CPRI";

        /// <summary>
        /// Initialize the algorithm with our custom data
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2017, 1, 1);
            SetEndDate(2019, 8, 1);
            SetCash(100000);

            _equitySymbol = AddEquity(_ticker, Resolution.Daily).Symbol;
            _weeklySymbol = AddData<BrainDataSentimentWeekly>(_ticker, Resolution.Daily).Symbol;
        }

        /// <summary>
        /// Loads each new data point into the algorithm. On sentiment data, we place orders depending on the sentiment
        /// </summary>
        /// <param name="message">Weekly sentiment data object</param>
        public override void OnData(Slice data)
        {
            foreach (var kvp in data.SymbolChangedEvents)
            {
                Log($"{Time} - Symbol: {kvp.Key.Value} - Renaming from {kvp.Value.OldSymbol} to {kvp.Value.NewSymbol}");
            }

            if (!data.ContainsKey(_weeklySymbol))
            {
                return;
            }

            var message = data[_weeklySymbol];

            if (!Portfolio.ContainsKey(_equitySymbol) || message == null)
            {
                return;
            }

            if (!Portfolio[_equitySymbol].Invested && Transactions.GetOpenOrders().Count == 0 && message.SentimentScore > 0.07m)
            {
                Log($"{Time} - Order placed for {message.Symbol.Value}");
                SetHoldings(_equitySymbol, 0.5);
            }
            else if (Portfolio[_equitySymbol].Invested && message.SentimentScore < -0.05m)
            {
                Log($"{Time} - Liquidating {message.Symbol.Value} - Current Qty: {Portfolio[_equitySymbol].Quantity}");
                Liquidate(_equitySymbol);
            }
        }
    }
}
