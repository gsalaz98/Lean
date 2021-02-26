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
 *
*/

using System;
using System.Collections.Generic;
using System.Linq;
using QuantConnect.Data.Market;
using QuantConnect.Indicators;
using QuantConnect.Interfaces;
using QuantConnect.Orders;
using QuantConnect.Securities;

namespace QuantConnect.Lean.Engine.Results
{
    internal class SymbolCapacity
    {
        private const decimal _forexMinuteVolume = 25000000m;

        private readonly IAlgorithm _algorithm;
        private readonly Symbol _symbol;
        private readonly SecurityHolding _holding;
        private readonly Security _security;

        private decimal _previousVolume;
        private DateTime? _previousTime;

        private decimal _averageVolume;
        private OrderEvent _previousOrderEvent;

        public DateTime Timeout { get; private set; }


        public decimal SaleVolume { get; private set; }

        public decimal MarketCapacityDollarVolume { get; private set; }

        public decimal TotalHoldingsInDollars => _holding.HoldingsValue;

        public SymbolCapacity(IAlgorithm algorithm, Symbol symbol)
        {
            _algorithm = algorithm;
            _security = _algorithm.Securities[symbol];
            _symbol = symbol;
            _holding = _algorithm.Portfolio[_symbol];
        }

        public void OnOrderEvent(OrderEvent orderEvent)
        {
            var saleVolume = orderEvent.FillPrice * orderEvent.AbsoluteFillQuantity * _security.SymbolProperties.ContractMultiplier;
            if (orderEvent.UtcTime.Date != _previousOrderEvent?.UtcTime.Date)
            {
                SaleVolume = saleVolume;
            }
            else
            {
                SaleVolume += saleVolume;
            }

            var k = _averageVolume != 0
                ? 6000000 / _averageVolume
                : 10;

            var timeoutMinutes = k > 120 ? 120 : (int)Math.Max(5, (double)k);

            Timeout = _algorithm.UtcTime.AddMinutes(timeoutMinutes);
        }

        public bool UpdateMarketCapacity()
        {
            var bar = GetBar();
            if (bar == null)
            {
                return false;
            }

            var utcTime = _algorithm.UtcTime;
            var volume = Volume(bar);
            var timeBetweenBars = (decimal)(utcTime - (_previousTime ?? utcTime)).TotalMinutes;


            if (_previousTime == null || timeBetweenBars == 0)
            {
                _previousTime = utcTime;
                _previousVolume = volume;
                _averageVolume = bar.Close * volume;

                return false;
            }

            _averageVolume = (bar.Close * (volume + _previousVolume)) / timeBetweenBars;

            _previousTime = utcTime;
            _previousVolume = volume;

            var beforeTimeout = utcTime <= Timeout;
            if (beforeTimeout)
            {
                MarketCapacityDollarVolume += bar.Close * volume * _security.SymbolProperties.ContractMultiplier * 0.20m;
            }

            return !beforeTimeout;
        }

        private decimal Volume(TradeBar bar)
        {
            if (_symbol.SecurityType == SecurityType.Forex)
            {
                return _forexMinuteVolume;
            }

            return bar.Volume;
        }

        private TradeBar GetBar()
        {
            TradeBar bar;
            if (_algorithm.CurrentSlice.Bars.TryGetValue(_symbol, out bar))
            {
                return bar;
            }

            QuoteBar quote;
            if (_algorithm.CurrentSlice.QuoteBars.TryGetValue(_symbol, out quote))
            {
                // Fake a tradebar for quote data using market depth as a proxy for volume
                bar = new TradeBar(
                    quote.Time,
                    quote.Symbol,
                    quote.Open,
                    quote.High,
                    quote.Low,
                    quote.Close,
                    (quote.LastBidSize + quote.LastAskSize) / 2);

                return bar;
            }

            return null;
        }
    }
}
