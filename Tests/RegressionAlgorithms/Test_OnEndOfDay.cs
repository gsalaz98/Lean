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
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using QuantConnect.Algorithm;
using QuantConnect.Data.Market;
using QuantConnect.Orders;

namespace QuantConnect
{
    using QuantConnect.Interfaces;
    using QuantConnect.Securities;
    

    public partial class TestOnEndOfDay : QCAlgorithm, IAlgorithm
    {
        string symbol = "SPY";

        public override void Initialize()
        {
            SetStartDate(2013, 1, 1);
            SetEndDate(2014, 1, 1);
            SetCash(30000);
            AddSecurity(SecurityType.Equity, symbol, Resolution.Minute);
        }

        public void OnTradeBar(Dictionary<string, TradeBar> data)
        {
            if (Portfolio.HoldStock == false)
            {
                Order(symbol, 50);
            }
        }

        public override void OnEndOfDay()
        {
            Debug(Time.Date.ToShortDateString() + " EOD Message.");
        }
    }
}