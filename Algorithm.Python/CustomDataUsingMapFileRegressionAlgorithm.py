﻿# QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
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
from QuantConnect.Data.Custom.SEC import *

### <summary>
### Demonstration algorithm showing how to use and access SEC data
### </summary>
### <meta name="tag" content="using data" />
### <meta name="tag" content="custom data" />
### <meta name="tag" content="regression test" />
### <meta name="tag" content="SEC" />
### <meta name="tag" content="rename event" />
### <meta name="tag" content="map" />
### <meta name="tag" content="mapping" />
### <meta name="tag" content="map files" />
class CustomDataUsingMapFileRegressionAlgorithm(QCAlgorithm):

    def Initialize(self):
        # Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        self.SetStartDate(2001, 1, 1)
        self.SetEndDate(2003, 12, 31)
        self.SetCash(100000)

        self.ticker = "TWX"
        self.symbol = self.AddData(SECReport8K, self.ticker).Symbol
        self.AddEquity(self.ticker, Resolution.Daily)

    def OnData(self, slice):
        if slice.SymbolChangedEvents.ContainsKey(self.symbol):
            self.changed_symbol = True
            self.Log("{0} - Ticker changed from: {1} to {2}".format(str(self.Time), slice.SymbolChangedEvents[self.symbol].OldSymbol, slice.SymbolChangedEvents[self.symbol].NewSymbol))

    def OnEndOfAlgorithm(self):
        if not self.changed_symbol:
            raise Exception("The ticker did not rename throughout the course of its life even though it should have")


