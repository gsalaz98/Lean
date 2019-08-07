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

from clr import AddReference
AddReference("System")
AddReference("QuantConnect.Algorithm")
AddReference("QuantConnect.Common")

from System import *
from QuantConnect import *
from QuantConnect.Algorithm import *
from QuantConnect.Data.Custom.BrainData import *

### <summary>
### This example algorithm shows how to import and use Brain Data sentiment data
### </summary>
### <meta name="tag" content="strategy example" />
### <meta name="tag" content="using data" />
### <meta name="tag" content="custom data" />
### <meta name="tag" content="alternative data" />
### <meta name="tag" content="braindata" />
### <meta name="tag" content="sentiment" />
class BrainDataSentimentAlgorithm(QCAlgorithm):

    def Initialize(self):
        '''Initialise the algorithm with our custom data'''

        self.SetStartDate(2017, 1, 1)
        self.SetEndDate(2019, 8, 1)
        self.SetCash(100000)

        self.ticker = "CPRI"
        self.equitySymbol = self.AddEquity(self.ticker, Resolution.Daily).Symbol
        self.weeklySymbol = self.AddData(BrainDataSentimentWeekly, self.ticker, Resolution.Daily).Symbol

    def OnData(self, data):
        '''
        Loads each new data point into the algorithm. On sentiment data, we place orders depending on the sentiment
        '''
        for kvp in data.SymbolChangedEvents:
            self.Log(f"{str(self.Time)} - Symbol: {kvp.Key.Value} - Renaming from {kvp.Value.OldSymbol} to {kvp.Value.NewSymbol}")

        if not data.ContainsKey(self.weeklySymbol):
            return

        message = data[self.weeklySymbol]

        if not self.Portfolio.ContainsKey(self.equitySymbol) or message is None:
            return

        if not self.Portfolio[self.equitySymbol].Invested and len(self.Transactions.GetOpenOrders()) == 0 and message.SentimentScore > 0.07:
            self.Log(f"{str(self.Time)} - Order placed for {message.Symbol.Value}")
            self.SetHoldings(self.equitySymbol, 0.5)

        elif self.Portfolio[self.equitySymbol].Invested and message.SentimentScore < -0.05:
            self.Log(f"{str(self.Time)} - Liquidating {message.Symbol.Value} - Current Qty: {self.Portfolio[self.equitySymbol].Quantity}")
            self.Liquidate(self.equitySymbol)

