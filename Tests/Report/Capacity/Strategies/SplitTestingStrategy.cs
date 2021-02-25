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

using QuantConnect.Algorithm;
using QuantConnect.Data;

namespace QuantConnect.Tests.Report.Capacity.Strategies
{
    public class SplitTestingStrategy : QCAlgorithm
    {
        private Symbol _htgm;

        public override void Initialize()
        {
            SetStartDate(2020, 11, 1);
            SetEndDate(2020, 12, 5);
            SetCash(100000);

            var htgm = AddEquity("HTGM", Resolution.Hour);
            htgm.SetDataNormalizationMode(DataNormalizationMode.Raw);
            _htgm = htgm.Symbol;
        }

        public override void OnData(Slice data)
        {
            if (!Portfolio.Invested)
            {
                SetHoldings(_htgm, 1);
            }
            else
            {
                SetHoldings(_htgm, -1);
            }
        }
    }
}
