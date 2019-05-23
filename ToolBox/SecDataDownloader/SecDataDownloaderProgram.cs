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

using QuantConnect.Data.Custom.Sec;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.ToolBox.SecDataDownloader
{
    public static class SecDataDownloaderProgram
    {
        public static void SecDataDownloader(DateTime startDate, DateTime endDate)
        {
            // Create dummy symbol
            var symbol = Symbol.Create("FOO", SecurityType.Equity, Market.USA);
            var downloader = new SecDataDownloader();

            downloader.Get(symbol, Resolution.Tick, startDate, endDate);
        }
    }
}
