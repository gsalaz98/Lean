# QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
# Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

from datetime import datetime, timedelta

from QuantConnect import *
from QuantConnect.Algorithm import *
from QuantConnect.Data import *
from QuantConnect.Data.Market import *
from QuantConnect.Data.UniverseSelection import *
from QuantConnect.Securities import *
from QuantConnect.Securities.Future import *
from QuantConnect import Market

class CoarseUniverseSelectionSymbolsRemovedOnHolidayRegressionAlgorithm(QCAlgorithm):

    def Initialize(self):
        self.SetStartDate(2020, 6, 1)
        self.SetEndDate(2020,11,9)
        self.SetCash(10000)
        self.AddUniverse(self.CoarseSelection)
        self.UniverseSettings.Resolution = Resolution.Daily

    def CoarseSelection(self, coarse):
        AllSecurities = [ x for x in coarse ]
        self.Plot("Strategy Equity", "AllSecurities", len(AllSecurities))

        if len(AllSecurities) == 0:
            self.Debug(str(self.Time))

        Stocks = [x for x in AllSecurities if (x.HasFundamentalData) and (float(x.Price) > 0)]
        self.Plot("Strategy Equity", "Stocks", len(Stocks))

        StocksAboveFive = [x for x in Stocks if (x.HasFundamentalData) and (float(x.Price) > 5)]
        self.Plot("Strategy Equity", "StocksAboveFive", len(StocksAboveFive))

        TopDollarVolume = sorted(StocksAboveFive, key=lambda x: x.DollarVolume, reverse=True)[:500]
        self.Plot("Strategy Equity", "TopDollarVolume", len(TopDollarVolume))

        return  [x.Symbol for x in TopDollarVolume[:500]]

    def OnSecuritiesChanged(self, changes: SecurityChanges):
        self.Log(f"{self.Time} - Removed securities: {len(changes.RemovedSecurities)}")
