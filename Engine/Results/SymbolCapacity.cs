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
using System.Linq;
using QuantConnect.Data.Market;
using QuantConnect.Interfaces;
using QuantConnect.Orders;
using QuantConnect.Securities;

namespace QuantConnect.Lean.Engine.Results
{
    internal class SymbolCapacity
    {
        /// <summary>
        /// An estimate of how much volume the FX market trades per minute
        /// </summary>
        private const decimal _forexMinuteVolume = 25000000m;
        private const decimal _fastTradingVolumeScalingFactor = 2m;

        private readonly IAlgorithm _algorithm;
        private readonly Symbol _symbol;
        private readonly SecurityHolding _holding;

        private decimal _previousVolume;
        private DateTime? _previousTime;

        private decimal _averageDollarVolume;
        private decimal _marketCapacityDollarVolume;
        private bool _resetMarketCapacityDollarVolume;
        private decimal _fastTradingVolumeDiscountFactor;
        private OrderEvent _previousOrderEvent;
        private TradeBar _previousBar;
        private Resolution _resolution;

        public Security Security { get; }

        private decimal _resolutionScaleFactor
        {
            get
            {
                switch (_resolution)
                {
                    case Resolution.Daily:
                        return 0.02m;

                    case Resolution.Hour:
                        return 0.05m;

                    case Resolution.Minute:
                        return 0.20m;

                    case Resolution.Tick:
                    case Resolution.Second:
                        return 0.50m;

                    default:
                        return 1m;
                }
            }
        }
        public decimal SaleVolume { get; private set; }

        public decimal MarketCapacityDollarVolume => _marketCapacityDollarVolume * _resolutionScaleFactor;

        public decimal TotalHoldingsInDollars => _holding.HoldingsValue;

        public SymbolCapacity(IAlgorithm algorithm, Symbol symbol)
        {
            _algorithm = algorithm;
            Security = _algorithm.Securities[symbol];
            _symbol = symbol;
            _holding = _algorithm.Portfolio[_symbol];

            var resolution = Security.Subscriptions
                .Where(s => !s.IsInternalFeed)
                .OrderBy(s => s.Resolution)
                .FirstOrDefault()?
                .Resolution;

            _resolution = resolution == null || resolution == Resolution.Tick
                ? Resolution.Second
                : resolution.Value;
        }

        public void OnOrderEvent(OrderEvent orderEvent)
        {
            SaleVolume += Security.QuoteCurrency.ConversionRate * orderEvent.FillPrice * orderEvent.AbsoluteFillQuantity * Security.SymbolProperties.ContractMultiplier;

            // To reduce the capacity of high frequency strategies, we scale down the
            // volume captured on each bar proportional to the trades per day.
            // Default to -1 day for the first order to not reduce the volume of the first order.
            _fastTradingVolumeDiscountFactor = _fastTradingVolumeScalingFactor * ((decimal)((orderEvent.UtcTime - (_previousOrderEvent?.UtcTime ?? orderEvent.UtcTime.AddDays(-1))).TotalMinutes) / 390m);
            _fastTradingVolumeDiscountFactor = _fastTradingVolumeDiscountFactor > 1 ? 1 : Math.Max(0.20m, _fastTradingVolumeDiscountFactor);

            if (_resetMarketCapacityDollarVolume)
            {
                _marketCapacityDollarVolume = 0;
                _resetMarketCapacityDollarVolume = false;
            }

            _previousOrderEvent = orderEvent;
        }

        private bool IncludeMarketVolume()
        {
            if (_previousOrderEvent == null)
            {
                return false;
            }

            var dollarVolumeScaleFactor = 6000000;
            DateTime timeout;
            decimal k;

            switch (_resolution)
            {
                case Resolution.Tick:
                case Resolution.Second:
                    dollarVolumeScaleFactor = dollarVolumeScaleFactor / 60;
                    k = _averageDollarVolume != 0
                        ? dollarVolumeScaleFactor / _averageDollarVolume
                        : 10;

                    var timeoutPeriod = k > 120 ? 120 : (int)Math.Max(5, (double)k);
                    timeout = _previousOrderEvent.UtcTime.AddMinutes(timeoutPeriod);
                    break;

                case Resolution.Minute:
                    k = _averageDollarVolume != 0
                        ? dollarVolumeScaleFactor / _averageDollarVolume
                        : 10;

                    var timeoutMinutes = k > 120 ? 120 : (int)Math.Max(1, (double)k);
                    timeout = _previousOrderEvent.UtcTime.AddMinutes(timeoutMinutes);
                    break;

                case Resolution.Hour:
                    return _algorithm.UtcTime == _previousOrderEvent.UtcTime.RoundUp(_resolution.ToTimeSpan());

                case Resolution.Daily:
                    // At the end of a daily bar, the EndTime is the next day.
                    // Increment the order by one day to match it
                    return _algorithm.UtcTime.Date == _previousOrderEvent.UtcTime.RoundUp(_resolution.ToTimeSpan());

                default:
                    timeout = _previousOrderEvent.UtcTime.AddHours(1);
                    break;
            }

            return _algorithm.UtcTime <= timeout;
        }

        public bool UpdateMarketCapacity()
        {
            var bar = GetBar();
            if (bar == null || bar.Volume == 0)
            {
                return false;
            }

            _previousBar = bar;

            var utcTime = _algorithm.UtcTime;
            var conversionRate = Security.QuoteCurrency.ConversionRate;
            var timeBetweenBars = (decimal)(utcTime - (_previousTime ?? utcTime)).TotalMinutes;

            if (_previousTime == null || timeBetweenBars == 0)
            {
                _previousTime = utcTime;
                _previousVolume = bar.Volume;
                _averageDollarVolume = conversionRate * bar.Close * bar.Volume;
            }
            else
            {
                _averageDollarVolume = ((bar.Close * conversionRate) * (bar.Volume + _previousVolume)) / timeBetweenBars;
            }

            _previousTime = utcTime;
            _previousVolume = bar.Volume;

            var includeMarketVolume = IncludeMarketVolume();
            if (includeMarketVolume)
            {
                _marketCapacityDollarVolume += bar.Close * _fastTradingVolumeDiscountFactor * bar.Volume * conversionRate * Security.SymbolProperties.ContractMultiplier;
            }

            // When we've finished including market volume, signal completed
            return !includeMarketVolume;
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
                var volume = (quote.LastBidSize + quote.LastAskSize) / 2;
                volume = _symbol.SecurityType == SecurityType.Forex
                    ? _forexMinuteVolume
                    : volume;

                return new TradeBar(
                    quote.Time,
                    quote.Symbol,
                    quote.Open,
                    quote.High,
                    quote.Low,
                    quote.Close,
                    volume);
            }

            return null;
        }

        public void Reset()
        {
            _resetMarketCapacityDollarVolume = true;
            SaleVolume = 0;
        }
    }
}
