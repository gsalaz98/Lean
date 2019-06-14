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
using QuantConnect.Interfaces;
using QuantConnect.Data.Market;
using QuantConnect.Util;
using System.Globalization;
using System.Threading;
using QuantConnect.Data.Custom;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Regression algorithm demonstrating use of map files with custom data
    /// </summary>
    public class CustomDataUsingMapFileRegressionAlgorithm: QCAlgorithm, IRegressionAlgorithmDefinition
    {
        private Symbol _symbol;
        private bool _changedSymbol;
        
        /// <summary>
        /// Ticker we use for testing
        /// </summary>
        public string Ticker = "CPRI";

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2018, 1, 1);
            SetEndDate(2019, 5, 31);
            SetCash(100000);

            // KORS renamed to CPRI on 2019-01-02
            _symbol = AddData<RegressionAlgorithmUSEquities>("CPRI", Resolution.Daily).Symbol;
        }
        
        /// <summary>
        /// Checks to see if the stock has been renamed, and places an order once the symbol has changed
        /// </summary>
        /// <param name="slice"></param>
        public override void OnData(Slice slice)
        {
            if (slice.SymbolChangedEvents.ContainsKey(_symbol))
            {
                Log($"Ticker changed from: {slice.SymbolChangedEvents[_symbol].OldSymbol} to {slice.SymbolChangedEvents[_symbol].NewSymbol}");
                _changedSymbol = true;

                if (!Portfolio.Invested)
                {
                    SetHoldings(_symbol, 1.0m);
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
        };
    }
}
