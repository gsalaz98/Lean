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
using System.IO;
using System.Linq;
using NodaTime;
using QuantConnect.Algorithm;
using QuantConnect.Brokerages;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Data.UniverseSelection;
using QuantConnect.Lean.Engine;
using QuantConnect.Lean.Engine.DataFeeds.Enumerators;
using QuantConnect.Logging;
using QuantConnect.Orders;
using QuantConnect.Orders.Fees;
using QuantConnect.Packets;
using QuantConnect.Securities;
using QuantConnect.ToolBox;
using QuantConnect.Util;

namespace QuantConnect.Report.ReportElements
{
    internal sealed class EstimatedCapacityReportElement : ReportElement
    {
        private const Resolution _resolution = Resolution.Minute;
        private readonly LiveResult _live;
        private readonly BacktestResult _backtest;
        private readonly Dictionary<Symbol, DateTimeZone> _timeZones;
        private readonly SecurityManager _securityManager;
        private readonly CashBook _cashBook;
        private readonly SubscriptionManager _subscriptionManager;
        private readonly MarketHoursDatabase _mhdb;
        private readonly SymbolPropertiesDatabase _spdb;
        private readonly SecurityService _securityService;

        /// <summary>
        /// Create a new capacity estimate
        /// </summary>
        /// <param name="name">Name of the widget</param>
        /// <param name="key">Location of injection</param>
        /// <param name="backtest">Backtest result object</param>
        /// <param name="live">Live result object</param>
        public EstimatedCapacityReportElement(string name, string key, BacktestResult backtest, LiveResult live)
        {
            _live = live;
            _backtest = backtest;
            Name = name;
            Key = key;

            _timeZones = new Dictionary<Symbol, DateTimeZone>();
            _securityManager = new SecurityManager(new TimeKeeper(DateTime.UtcNow, TimeZones.NewYork, TimeZones.Utc));
            _cashBook = new CashBook();
            _subscriptionManager = new SubscriptionManager();
            _subscriptionManager.SetDataManager(new StubDataManager());
            _mhdb = MarketHoursDatabase.FromDataFolder();
            _spdb = SymbolPropertiesDatabase.FromDataFolder();
            _securityService = new SecurityService(
                _cashBook,
                _mhdb,
                _spdb,
                new QCAlgorithm(),
                new RegisteredSecurityDataTypesProvider(),
                new SecurityCacheProvider(new ReportSecurityProvider()));
        }

        public override string Render()
        {
            var orders = ((Result)_live ?? (Result)_backtest)
                .Orders
                .Values
                .OrderBy(o => o.LastFillTime)
                .ToList();

            if (orders.Count == 0)
            {
                return "-";
            }

            var start = orders[0].LastFillTime.Value;
            // Add a buffer of 1 day so that orders placed in the last trading day are snapshotted if the month changes.
            var end = orders[orders.Count - 1].LastFillTime.Value.AddDays(1);

            SetupDataSubscriptions(orders);

            var configs = _cashBook.EnsureCurrencyDataFeeds(
                _securityManager,
                _subscriptionManager,
                new DefaultBrokerageModel().DefaultMarkets,
                new SecurityChanges(_securityManager.Values, Array.Empty<Security>()),
                _securityService)
                .Concat(_subscriptionManager.Subscriptions);

            var capacity = AlgorithmCapacity(configs, orders, start, end).RoundToSignificantDigits(3);

            Result = capacity;
            return FormatNumber(capacity);
        }

        private void SetupDataSubscriptions(IEnumerable<Order> orders)
        {
            var symbols = LinqExtensions.ToHashSet(orders.Select(x => x.Symbol));

            foreach (var symbol in symbols)
            {
                var dataTimeZone = _mhdb.GetDataTimeZone(symbol.ID.Market, symbol, symbol.SecurityType);
                var exchangeTimeZone = _mhdb.GetExchangeHours(symbol.ID.Market, symbol, symbol.SecurityType).TimeZone;

                _timeZones[symbol] = exchangeTimeZone;

                var config = _subscriptionManager.Add(symbol, _resolution, dataTimeZone, exchangeTimeZone);
                _securityManager.Add(_securityService.CreateSecurity(config.Symbol, config));

                if (config.Symbol.SecurityType == SecurityType.Crypto)
                {
                    var quoteConfig = new SubscriptionDataConfig(config, tickType: TickType.Quote);
                    _subscriptionManager.Add(typeof(QuoteBar), TickType.Quote, symbol, _resolution, dataTimeZone, exchangeTimeZone, false);
                    _securityManager.Add(_securityService.CreateSecurity(quoteConfig.Symbol, quoteConfig));
                }
            }
        }

        private List<IEnumerator<BaseData>> ReadData(
            IEnumerable<SubscriptionDataConfig> configs,
            DateTime start,
            DateTime end)
        {
            var readers = new List<IEnumerator<BaseData>>();

            foreach (var config in configs)
            {
                foreach (var date in Time.EachDay(start, end))
                {
                    if (File.Exists(LeanData.GenerateZipFilePath(Globals.DataFolder, config.Symbol, date, _resolution, config.TickType)))
                    {
                        readers.Add(new LeanDataReader(config, config.Symbol, _resolution, date, Globals.DataFolder).Parse().GetEnumerator());
                    }
                }
            }

            return readers;
        }

        private List<List<BaseData>> SynchronizeData(IEnumerable<SubscriptionDataConfig> configs, DateTime start, DateTime end)
        {
            var readers = ReadData(configs, start, end);
            var dataEnumerators = readers.ToArray();
            var synchronizer = new SynchronizingEnumerator(dataEnumerators);

            var dataBinnedByTime = new List<List<BaseData>>();
            var currentData = new List<BaseData>();
            var currentTime = DateTime.MinValue;

            while (synchronizer.MoveNext())
            {
                if (synchronizer.Current == null || synchronizer.Current.EndTime > end)
                {
                    break;
                }

                if (synchronizer.Current.EndTime < start)
                {
                    continue;
                }

                if (currentTime == DateTime.MinValue)
                {
                    currentTime = synchronizer.Current.EndTime;
                }

                if (currentTime != synchronizer.Current.EndTime)
                {
                    dataBinnedByTime.Add(currentData);
                    currentData = new List<BaseData>();
                    currentData.Add(synchronizer.Current);
                    currentTime = synchronizer.Current.EndTime;

                    continue;
                }

                currentData.Add(synchronizer.Current);
            }

            if (currentData.Count != 0)
            {
                dataBinnedByTime.Add(currentData);
            }

            return dataBinnedByTime;
        }

        private void UpdateCurrencyConversionData(
            IEnumerable<SubscriptionDataConfig> configs,
            IEnumerable<BaseData> dataBin)
        {
            foreach (var config in configs)//conversionConfigs.Concat(_subscriptionManager.Subscriptions))
            {
                var symbol = config.Symbol;
                var cashMoney = _cashBook.Values.FirstOrDefault(x => x.ConversionRateSecurity?.Symbol == symbol);
                var currencyUpdateData = dataBin.FirstOrDefault(x => x.Symbol == symbol);

                if (cashMoney != null && currencyUpdateData != null)
                {
                    cashMoney.Update(currencyUpdateData);
                }
            }
        }

        private void DataToAccountCurrency(List<BaseData> dataBin)
        {
            foreach (var dataPoint in dataBin)
            {
                var symbolProperties = _spdb.GetSymbolProperties(dataPoint.Symbol.ID.Market, dataPoint.Symbol, dataPoint.Symbol.SecurityType, "USD");
                var bar = dataPoint as TradeBar;

                if (bar != null)
                {
                    // Actual units are:
                    // USD/BTC
                    // BTC/ETH
                    //
                    // 0.02541 BTC == 1 ETH
                    // 0.02541 BTC == 744 USD
                    // 0.02541 BTC/ETH * 29280 USD/BTC = 744 USD/ETH
                    // So converting from BTC to USD should be sufficient.
                    bar.Open = _cashBook.ConvertToAccountCurrency(bar.Open, symbolProperties.QuoteCurrency);
                    bar.High = _cashBook.ConvertToAccountCurrency(bar.High, symbolProperties.QuoteCurrency);
                    bar.Low = _cashBook.ConvertToAccountCurrency(bar.Low, symbolProperties.QuoteCurrency);
                    bar.Close = _cashBook.ConvertToAccountCurrency(bar.Close, symbolProperties.QuoteCurrency);
                    // We don't convert bar volume here, since it will be converted for us as dollar volume
                    // in the SymbolData class inside the StrategyCapacity class.
                    continue;
                }
                var quoteBar = dataPoint as QuoteBar;
                if (quoteBar != null)
                {
                    if (quoteBar.Bid != null)
                    {
                        quoteBar.Bid.Open = _cashBook.ConvertToAccountCurrency(quoteBar.Bid.Open, symbolProperties.QuoteCurrency);
                        quoteBar.Bid.High = _cashBook.ConvertToAccountCurrency(quoteBar.Bid.High, symbolProperties.QuoteCurrency);
                        quoteBar.Bid.Low = _cashBook.ConvertToAccountCurrency(quoteBar.Bid.Low, symbolProperties.QuoteCurrency);
                        quoteBar.Bid.Close = _cashBook.ConvertToAccountCurrency(quoteBar.Bid.Close, symbolProperties.QuoteCurrency);
                    }
                    if (quoteBar.Ask != null)
                    {
                        quoteBar.Ask.Open = _cashBook.ConvertToAccountCurrency(quoteBar.Ask.Open, symbolProperties.QuoteCurrency);
                        quoteBar.Ask.High = _cashBook.ConvertToAccountCurrency(quoteBar.Ask.High, symbolProperties.QuoteCurrency);
                        quoteBar.Ask.Low = _cashBook.ConvertToAccountCurrency(quoteBar.Ask.Low, symbolProperties.QuoteCurrency);
                        quoteBar.Ask.Close = _cashBook.ConvertToAccountCurrency(quoteBar.Ask.Close, symbolProperties.QuoteCurrency);
                    }
                }
            }
        }

        private List<OrderEvent> ToOrderEvents(List<Order> orders, DateTime dataTime, ref int cursor)
        {
            var orderEvents = new List<OrderEvent>();

            while (cursor < orders.Count)
            {
                var order = orders[cursor];
                var exchangeHours = _mhdb.GetEntry(order.Symbol.ID.Market, order.Symbol, order.Symbol.SecurityType)
                    .ExchangeHours;

                var orderEvent = new OrderEvent(order, order.LastFillTime.Value, OrderFee.Zero);
                var symbolProperties = _spdb.GetSymbolProperties(order.Symbol.ID.Market, order.Symbol, order.Symbol.SecurityType, "USD");

                // Price is in USD/ETH
                orderEvent.FillPrice = _cashBook.ConvertToAccountCurrency(order.Price, symbolProperties.QuoteCurrency);
                // Qty is in ETH, (ETH/1) * (USD/ETH) == USD
                // However, the OnData handler inside SymbolData in the StrategyCapacity
                // class will multiply this for us, so let's keep this in the asset quantity for now.
                orderEvent.FillQuantity = order.Quantity;
                orderEvent.UtcTime = order.Type == OrderType.MarketOnOpen
                    ? exchangeHours.GetNextMarketOpen(orderEvent.UtcTime.ConvertFromUtc(_timeZones[order.Symbol]), false).AddMinutes(1).ConvertToUtc(_timeZones[order.Symbol])
                    : orderEvent.UtcTime;

                if (orderEvent.UtcTime.ConvertFromUtc(_timeZones[order.Symbol]) > dataTime)
                {
                    break;
                }

                orderEvents.Add(orderEvent);
                cursor++;
            }

            return orderEvents;
        }

        private decimal AlgorithmCapacity(
            IEnumerable<SubscriptionDataConfig> configs,
            List<Order> orders,
            DateTime start,
            DateTime end)
        {
            var dataBinnedByTime = SynchronizeData(configs, start, end);
            var symbols = LinqExtensions.ToHashSet(orders.Select(x => x.Symbol));
            var strategyCapacity = new StrategyCapacity(_timeZones);
            var cursor = 0;

            foreach (var dataBin in dataBinnedByTime)
            {
                UpdateCurrencyConversionData(configs, dataBin);
                DataToAccountCurrency(dataBin);

                var dataTime = dataBin[0].EndTime;
                var orderEvents = ToOrderEvents(orders, dataTime, ref cursor);

                var slice = new Slice(dataTime, dataBin.Where(x => symbols.Contains(x.Symbol)));
                strategyCapacity.OnData(slice);

                foreach (var orderEvent in orderEvents)
                {
                    strategyCapacity.OnOrderEvent(orderEvent);
                }
            }

            return strategyCapacity.Capacity.Last().y;
        }

        private static string FormatNumber(decimal number)
        {
            if (number < 1000)
            {
                return number.ToStringInvariant();
            }

            // Subtract by multiples of 5 to round down to nearest round number
            if (number < 10000)
            {
                return $"{number - 5m:#,.##}K";
            }

            if (number < 100000)
            {
                return $"{number - 50m:#,.#}K";
            }

            if (number < 1000000)
            {
                return $"{number - 500m:#,.}K";
            }

            if (number < 10000000)
            {
                return $"{number - 5000m:#,,.##}M";
            }

            if (number < 100000000)
            {
                return $"{number - 50000m:#,,.#}M";
            }

            if (number < 1000000000)
            {
                return $"{number - 500000m:#,,.}M";
            }

            return $"{number - 5000000m:#,,,.##}B";
        }
    }
}
