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
using QuantConnect.Data;
using QuantConnect.Data.Custom;
using QuantConnect.Interfaces;
using QuantConnect.Orders.Fees;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Regression algorithm demonstrating use of map files with custom data
    /// </summary>
    public class CustomDataUsingMapFileRegressionAlgorithm: QCAlgorithm, IRegressionAlgorithmDefinition
    {
        private Symbol _symbol;
        private bool _changedSymbol;
        private DateTime _actualStartDate = default(DateTime);
        private DateTime _startDate = new DateTime(2018, 1, 1);
        private DateTime _endDate = new DateTime(2019, 5, 31);

        /// <summary>
        /// Ticker we use for testing
        /// </summary>
        public const string Ticker = "CPRI";

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(_startDate.Year, _startDate.Month, _startDate.Day);
            SetEndDate(_endDate.Year, _endDate.Month, _endDate.Day);
            SetCash(100000);
            SetBrokerageModel(Brokerages.BrokerageName.Default, AccountType.Cash);


            // KORS renamed to CPRI on 2019-01-02
            _symbol = AddData<RegressionAlgorithmUSEquities>(Ticker, Resolution.Daily, false, leverage: 2.0m).Symbol;
            Securities[_symbol].FeeModel = new ConstantFeeModel(1.00m);
        }
        
        /// <summary>
        /// Checks to see if the stock has been renamed, and places an order once the symbol has changed
        /// </summary>
        /// <param name="slice"></param>
        public override void OnData(Slice slice)
        {
            // On the initial piece of data, we receive a rename event mapping the current symbol to the oldest ticker.
            if (_actualStartDate == default(DateTime))
            {
                _actualStartDate = Time;
            }

            // Don't process the initial rename event
            if (slice.SymbolChangedEvents.ContainsKey(_symbol) && _actualStartDate != Time)
            {
                Log($"{Time:yyyy-MM-dd HH:mm:ss} - Ticker changed from: {slice.SymbolChangedEvents[_symbol].OldSymbol} to {slice.SymbolChangedEvents[_symbol].NewSymbol}");
                _changedSymbol = true;

                if (!Portfolio.Invested)
                {
                    SetHoldings(_symbol, 1.0m);
                    Log($"Bought {_symbol.Value} at {Time}");
                }
            }
        }
        
        /// <summary>
        /// Final step of the algorithm
        /// </summary>
        public override void OnEndOfAlgorithm()
        {
            if (!_changedSymbol)
            {
                throw new Exception("The ticker did not rename throughout the course of its life even though it should have");
            }
        }

        /// <summary>
        /// This is used by the regression test system to indicate if the open source Lean repository has the required data to run this algorithm.
        /// </summary>
        public bool CanRunLocally { get; } = false;

        /// <summary>
        /// This is used by the regression test system to indicate which languages this algorithm is written in.
        /// </summary>
        public Language[] Languages { get; } = { Language.CSharp };

        /// <summary>
        /// This is used by the regression test system to indicate what the expected statistics are from running the algorithm
        /// </summary>
        public Dictionary<string, string> ExpectedStatistics => new Dictionary<string, string>
        {
            {"Total Trades", "1"},
            {"Average Win", "0%"},
            {"Average Loss", "0%"},
            {"Compounding Annual Return", "-9.936%"},
            {"Drawdown", "34.600%"},
            {"Expectancy", "0"},
            {"Net Profit", "-13.751%"},
            {"Sharpe Ratio", "-0.353"},
            {"Loss Rate", "0%"},
            {"Win Rate", "0%"},
            {"Profit-Loss Ratio", "0"},
            {"Alpha", "0.105"},
            {"Beta", "-9.249"},
            {"Annual Standard Deviation", "0.224"},
            {"Annual Variance", "0.05"},
            {"Information Ratio", "-0.442"},
            {"Tracking Error", "0.224"},
            {"Treynor Ratio", "0.009"},
            {"Total Fees", "$1.00"},
        };
    }
}
