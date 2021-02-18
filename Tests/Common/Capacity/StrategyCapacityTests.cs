using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using NUnit.Framework;
using QuantConnect.Algorithm;
using QuantConnect.Brokerages;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Data.UniverseSelection;
using QuantConnect.Lean.Engine.DataFeeds.Enumerators;
using QuantConnect.Logging;
using QuantConnect.Orders;
using QuantConnect.Orders.Fees;
using QuantConnect.Packets;
using QuantConnect.Report;
using QuantConnect.Securities;
using QuantConnect.Tests.Brokerages;
using QuantConnect.Tests.Common.Capacity.Strategies;
using QuantConnect.Tests.Engine.DataFeeds;
using QuantConnect.ToolBox;
using QuantConnect.Util;

namespace QuantConnect.Tests.Common.Capacity
{
    [TestFixture]
    public class StrategyCapacityTests
    {
        [TestCase(nameof(SpyBondPortfolioRebalance), 162000000)]
        [TestCase(nameof(BeastVsPenny), 88600)]
        [TestCase(nameof(MonthlyRebalanceHourly), 29700000)]
        [TestCase(nameof(MonthlyRebalanceDaily), 23800000)]
        [TestCase(nameof(IntradayMinuteScalping), 25600000)]
        [TestCase("IntradayMinuteScalpingBTCETH", 2000)]
        [TestCase(nameof(EmaPortfolioRebalance100), 102)]
        public void TestCapacity(string strategy, int expectedCapacity)
        {
            var timeZones = new Dictionary<Symbol, DateTimeZone>();
            var mhdb = MarketHoursDatabase.FromDataFolder();
            var spdb = SymbolPropertiesDatabase.FromDataFolder();
            var resolution = Resolution.Minute;

            var securityManager = new SecurityManager(new TimeKeeper(DateTime.UtcNow, TimeZones.NewYork, TimeZones.Utc));
            var cashBook = new CashBook();
            var subscriptionManager = new SubscriptionManager();
            subscriptionManager.SetDataManager(new DataManagerStub());
            var securityService = new SecurityService(
                cashBook,
                mhdb,
                spdb,
                new QCAlgorithm(),
                new RegisteredSecurityDataTypesProvider(),
                new SecurityCacheProvider(new SecurityProvider()));

            var orders = JsonConvert.DeserializeObject<BacktestResult>(File.ReadAllText(Path.Combine("Common", "Capacity", "Strategies", $"{strategy}.json")), new OrderJsonConverter())
                .Orders
                .Values
                .OrderBy(o => o.LastFillTime)
                .ToList();

            if (orders.Count == 0)
            {
                throw new Exception("Expected non-zero amount of orders");
            }

            var start = orders[0].LastFillTime.Value;
            // Add a buffer of 1 day so that orders placed in the trading day
            // are snapshotted. In the case of MonthlyRebalanceDaily, the last data point we get
            // is at 2020-04-01 00:00:00 Eastern Time, but our last order came in on 12:00:00 Eastern time of the same day.
            // We need a buffer of at least 10 minutes, which afterwards the data will stop updating the statistics and no
            // new snapshots will be generated
            var end = orders[orders.Count - 1].LastFillTime.Value.AddDays(1);

            var readers = new List<IEnumerator<BaseData>>();
            var symbols = orders.Select(x => x.Symbol).ToHashSet();
            foreach (var symbol in symbols)
            {
                var dataTimeZone = mhdb.GetDataTimeZone(symbol.ID.Market, symbol, symbol.SecurityType);
                var exchangeTimeZone = mhdb.GetExchangeHours(symbol.ID.Market, symbol, symbol.SecurityType).TimeZone;
                timeZones[symbol] = exchangeTimeZone;

                var config = subscriptionManager.Add(symbol, resolution, dataTimeZone, exchangeTimeZone, false, true, false);
                securityManager.Add(securityService.CreateSecurity(config.Symbol, config));

                if (config.Symbol.SecurityType == SecurityType.Crypto)
                {
                    var quoteConfig = new SubscriptionDataConfig(config, tickType: TickType.Quote);
                    subscriptionManager.Add(typeof(QuoteBar), TickType.Quote, symbol, resolution, dataTimeZone, exchangeTimeZone, false);
                    securityManager.Add(securityService.CreateSecurity(quoteConfig.Symbol, quoteConfig));
                }
            }

            var conversionConfigs = cashBook.EnsureCurrencyDataFeeds(
                securityManager,
                subscriptionManager,
                new DefaultBrokerageModel().DefaultMarkets,
                new SecurityChanges(securityManager.Values, new Security[0]),
                securityService);

            foreach (var config in subscriptionManager.Subscriptions.Concat(conversionConfigs))
            {
                foreach (var date in Time.EachDay(start, end))
                {
                    if (File.Exists(LeanData.GenerateZipFilePath(Globals.DataFolder, config.Symbol, date, resolution, config.TickType)))
                    {
                        readers.Add(new LeanDataReader(config, config.Symbol, resolution, date, Globals.DataFolder).Parse().GetEnumerator());
                    }
                }
            }

            var strategyCapacity = new StrategyCapacity(timeZones);

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

            var cursor = 0;

            foreach (var dataBin in dataBinnedByTime)
            {
                var dataTime = dataBin[0].EndTime;
                foreach (var config in conversionConfigs.Concat(subscriptionManager.Subscriptions))
                {
                    var symbol = config.Symbol;
                    var cashMoney = cashBook.Values.FirstOrDefault(x => x.ConversionRateSecurity?.Symbol == symbol);
                    var currencyUpdateData = dataBin.FirstOrDefault(x => x.Symbol == symbol);

                    if (cashMoney != null && currencyUpdateData != null)
                    {
                        cashMoney.Update(currencyUpdateData);
                    }
                }

                foreach (var dataPoint in dataBin)
                {
                    var symbolProperties = spdb.GetSymbolProperties(dataPoint.Symbol.ID.Market, dataPoint.Symbol, dataPoint.Symbol.SecurityType, "USD");
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
                        bar.Open = cashBook.ConvertToAccountCurrency(bar.Open, symbolProperties.QuoteCurrency);
                        bar.High = cashBook.ConvertToAccountCurrency(bar.High, symbolProperties.QuoteCurrency);
                        bar.Low = cashBook.ConvertToAccountCurrency(bar.Low, symbolProperties.QuoteCurrency);
                        bar.Close = cashBook.ConvertToAccountCurrency(bar.Close, symbolProperties.QuoteCurrency);
                        // We don't convert bar volume here, since it will be converted for us as dollar volume
                        // in the SymbolData class inside the StrategyCapacity class.
                        continue;
                    }
                    var quoteBar = dataPoint as QuoteBar;
                    if (quoteBar != null)
                    {
                        if (quoteBar.Bid != null)
                        {
                            quoteBar.Bid.Open = cashBook.ConvertToAccountCurrency(quoteBar.Bid.Open, symbolProperties.QuoteCurrency);
                            quoteBar.Bid.High = cashBook.ConvertToAccountCurrency(quoteBar.Bid.High, symbolProperties.QuoteCurrency);
                            quoteBar.Bid.Low = cashBook.ConvertToAccountCurrency(quoteBar.Bid.Low, symbolProperties.QuoteCurrency);
                            quoteBar.Bid.Close = cashBook.ConvertToAccountCurrency(quoteBar.Bid.Close, symbolProperties.QuoteCurrency);
                        }
                        if (quoteBar.Ask != null)
                        {
                            quoteBar.Ask.Open = cashBook.ConvertToAccountCurrency(quoteBar.Ask.Open, symbolProperties.QuoteCurrency);
                            quoteBar.Ask.High = cashBook.ConvertToAccountCurrency(quoteBar.Ask.High, symbolProperties.QuoteCurrency);
                            quoteBar.Ask.Low = cashBook.ConvertToAccountCurrency(quoteBar.Ask.Low, symbolProperties.QuoteCurrency);
                            quoteBar.Ask.Close = cashBook.ConvertToAccountCurrency(quoteBar.Ask.Close, symbolProperties.QuoteCurrency);
                        }
                    }
                }

                var slice = new Slice(dataTime, dataBin.Where(x => symbols.Contains(x.Symbol)));
                var orderEvents = new List<OrderEvent>();

                while (cursor < orders.Count)
                {
                    var order = orders[cursor];
                    var exchangeHours = mhdb.GetEntry(order.Symbol.ID.Market, order.Symbol, order.Symbol.SecurityType)
                        .ExchangeHours;

                    var orderEvent = new OrderEvent(order, order.LastFillTime.Value, OrderFee.Zero);
                    var symbolProperties = spdb.GetSymbolProperties(order.Symbol.ID.Market, order.Symbol, order.Symbol.SecurityType, "USD");

                    // Price is in USD/ETH
                    orderEvent.FillPrice = cashBook.ConvertToAccountCurrency(order.Price, symbolProperties.QuoteCurrency);
                    // Qty is in ETH, (ETH/1) * (USD/ETH) == USD
                    // However, the OnData handler inside SymbolData in the StrategyCapacity
                    // class will multiply this for us, so let's keep this in the asset quantity for now.
                    orderEvent.FillQuantity = order.Quantity;
                    orderEvent.UtcTime = order.Type == OrderType.MarketOnOpen
                        ? exchangeHours.GetNextMarketOpen(orderEvent.UtcTime.ConvertFromUtc(timeZones[order.Symbol]), false).AddMinutes(1).ConvertToUtc(timeZones[order.Symbol])
                        : orderEvent.UtcTime;

                    if (orderEvent.UtcTime.ConvertFromUtc(timeZones[order.Symbol]) > dataTime)
                    {
                        break;
                    }

                    orderEvents.Add(orderEvent);
                    cursor++;
                }

                strategyCapacity.OnData(slice);

                foreach (var orderEvent in orderEvents)
                {
                    strategyCapacity.OnOrderEvent(orderEvent);
                }
            }

            foreach (var capacity in strategyCapacity.Capacity)
            {
                Log.Trace($"Capacity {Time.UnixTimeStampToDateTime(capacity.x)} {capacity.y}");
            }

            Assert.AreEqual(expectedCapacity, (double)strategyCapacity.Capacity.Last().y.RoundToSignificantDigits(3), 1.0);
        }

        [Test]
        public void CopyFilesFromRemoteSource()
        {
            var start = new DateTime(2020, 1, 1);
            var end = new DateTime(2020, 1, 31);

            var resolutions = new[] { Resolution.Minute, Resolution.Hour, Resolution.Daily };
            foreach (var symbol in JsonConvert.DeserializeObject<List<Symbol>>(File.ReadAllText(Path.Combine("Common", "Capacity", "symbols.json"))))
            {
                foreach (var resolution in resolutions)
                {
                    if (resolution < Resolution.Hour)
                    {
                        foreach (var date in Time.EachDay(start, end))
                        {
                            var filePath = LeanData.GenerateZipFilePath(Globals.DataFolder, symbol, date, resolution, TickType.Trade);
                            var filePathOutput = LeanData.GenerateZipFilePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data")), symbol, date, resolution, TickType.Trade);
                            if (File.Exists(filePath) && !File.Exists(filePathOutput))
                            {
                                Directory.GetParent(filePathOutput).Create();
                                File.Copy(filePath, filePathOutput);
                            }
                        }
                    }
                    else
                    {
                        var filePath = LeanData.GenerateZipFilePath(Globals.DataFolder, symbol, end, resolution, TickType.Trade);
                        var filePathOutput = LeanData.GenerateZipFilePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data")), symbol, end, resolution, TickType.Trade);
                        if (File.Exists(filePath) && !File.Exists(filePathOutput))
                        {
                            Directory.GetParent(filePathOutput).Create();
                            File.Copy(filePath, filePathOutput);
                        }
                    }
                }
            }
        }
    }
}
