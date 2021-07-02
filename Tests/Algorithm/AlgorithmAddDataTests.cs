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
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using NUnit.Framework;
using QuantConnect.Algorithm;
using QuantConnect.Algorithm.Selection;
using QuantConnect.AlgorithmFactory.Python.Wrappers;
using QuantConnect.Configuration;
using QuantConnect.Data;
using QuantConnect.Data.Auxiliary;
using QuantConnect.Data.Consolidators;
using QuantConnect.Data.Custom;
using QuantConnect.Data.Market;
using QuantConnect.Data.UniverseSelection;
using QuantConnect.Lean.Engine.DataFeeds;
using QuantConnect.Securities;
using QuantConnect.Tests.Engine.DataFeeds;
using QuantConnect.Util;
using Bitcoin = QuantConnect.Algorithm.CSharp.LiveTradingFeaturesAlgorithm.Bitcoin;
using HistoryRequest = QuantConnect.Data.HistoryRequest;

namespace QuantConnect.Tests.Algorithm
{
    [TestFixture]
    public class AlgorithmAddDataTests
    {
        [Test]
        public void DefaultDataFeeds_CanBeOverwritten_Successfully()
        {
            var algo = new QCAlgorithm();
            algo.SubscriptionManager.SetDataManager(new DataManagerStub(algo));

            // forex defult - should be quotebar
            var forexTrade = algo.AddForex("EURUSD");
            Assert.IsTrue(forexTrade.Subscriptions.Count() == 1);
            Assert.IsTrue(GetMatchingSubscription(forexTrade, typeof(QuoteBar)) != null);

            // Change
            Config.Set("security-data-feeds", "{ Forex: [\"Trade\"] }");
            var dataFeedsConfigString = Config.Get("security-data-feeds");
            Dictionary<SecurityType, List<TickType>> dataFeeds = new Dictionary<SecurityType, List<TickType>>();
            if (dataFeedsConfigString != string.Empty)
            {
                dataFeeds = JsonConvert.DeserializeObject<Dictionary<SecurityType, List<TickType>>>(dataFeedsConfigString);
            }

            algo.SetAvailableDataTypes(dataFeeds);

            // new forex - should be tradebar
            var forexQuote = algo.AddForex("EURUSD");
            Assert.IsTrue(forexQuote.Subscriptions.Count() == 1);
            Assert.IsTrue(GetMatchingSubscription(forexQuote, typeof(TradeBar)) != null);

            // reset to empty string, affects other tests because config is static
            Config.Set("security-data-feeds", "");
        }

        [Test]
        public void DefaultDataFeeds_AreAdded_Successfully()
        {
            var algo = new QCAlgorithm();
            algo.SubscriptionManager.SetDataManager(new DataManagerStub(algo));

            // forex
            var forex = algo.AddSecurity(SecurityType.Forex, "eurusd");
            Assert.IsTrue(forex.Subscriptions.Count() == 1);
            Assert.IsTrue(GetMatchingSubscription(forex, typeof(QuoteBar)) != null);

            // equity high resolution
            var equityMinute = algo.AddSecurity(SecurityType.Equity, "goog");
            Assert.IsTrue(equityMinute.Subscriptions.Count() == 2);
            Assert.IsTrue(GetMatchingSubscription(equityMinute, typeof(TradeBar)) != null);
            Assert.IsTrue(GetMatchingSubscription(equityMinute, typeof(QuoteBar)) != null);

            // equity low resolution
            var equityDaily = algo.AddSecurity(SecurityType.Equity, "goog", Resolution.Daily);
            Assert.IsTrue(equityDaily.Subscriptions.Count() == 1);
            Assert.IsTrue(GetMatchingSubscription(equityDaily, typeof(TradeBar)) != null);


            // option
            var option = algo.AddSecurity(SecurityType.Option, "goog");
            Assert.IsTrue(option.Subscriptions.Count() == 1);
            Assert.IsTrue(GetMatchingSubscription(option, typeof(ZipEntryName)) != null);

            // cfd
            var cfd = algo.AddSecurity(SecurityType.Cfd, "abc");
            Assert.IsTrue(cfd.Subscriptions.Count() == 1);
            Assert.IsTrue(GetMatchingSubscription(cfd, typeof(QuoteBar)) != null);

            // future
            var future = algo.AddSecurity(SecurityType.Future, "ES");
            Assert.IsTrue(future.Subscriptions.Count() == 1);
            Assert.IsTrue(future.Subscriptions.FirstOrDefault(x => typeof(ZipEntryName).IsAssignableFrom(x.Type)) != null);

            // Crypto high resolution
            var cryptoMinute = algo.AddSecurity(SecurityType.Equity, "goog");
            Assert.IsTrue(cryptoMinute.Subscriptions.Count() == 2);
            Assert.IsTrue(GetMatchingSubscription(cryptoMinute, typeof(TradeBar)) != null);
            Assert.IsTrue(GetMatchingSubscription(cryptoMinute, typeof(QuoteBar)) != null);

            // Crypto low resolution
            var cryptoHourly = algo.AddSecurity(SecurityType.Crypto, "btcusd", Resolution.Hour);
            Assert.IsTrue(cryptoHourly.Subscriptions.Count() == 2);
            Assert.IsTrue(GetMatchingSubscription(cryptoHourly, typeof(TradeBar)) != null);
            Assert.IsTrue(GetMatchingSubscription(cryptoHourly, typeof(QuoteBar)) != null);
        }


        [Test]
        public void CustomDataTypes_AreAddedToSubscriptions_Successfully()
        {
            var qcAlgorithm = new QCAlgorithm();
            qcAlgorithm.SubscriptionManager.SetDataManager(new DataManagerStub(qcAlgorithm));

            // Add a bitcoin subscription
            qcAlgorithm.AddData<Bitcoin>("BTC");
            var bitcoinSubscription = qcAlgorithm.SubscriptionManager.Subscriptions.FirstOrDefault(x => x.Type == typeof(Bitcoin));
            Assert.AreEqual(bitcoinSubscription.Type, typeof(Bitcoin));

            // Add a quandl subscription
            qcAlgorithm.AddData<Quandl>("EURCAD");
            var quandlSubscription = qcAlgorithm.SubscriptionManager.Subscriptions.FirstOrDefault(x => x.Type == typeof(Quandl));
            Assert.AreEqual(quandlSubscription.Type, typeof(Quandl));
        }

        [Test]
        public void OnEndOfTimeStepSeedsUnderlyingSecuritiesThatHaveNoData()
        {
            var qcAlgorithm = new QCAlgorithm();
            qcAlgorithm.SubscriptionManager.SetDataManager(new DataManagerStub(qcAlgorithm, new MockDataFeed()));
            qcAlgorithm.SetLiveMode(true);
            var testHistoryProvider = new TestHistoryProvider();
            qcAlgorithm.HistoryProvider = testHistoryProvider;

            var option = qcAlgorithm.AddSecurity(SecurityType.Option, testHistoryProvider.underlyingSymbol);
            var option2 = qcAlgorithm.AddSecurity(SecurityType.Option, testHistoryProvider.underlyingSymbol2);
            Assert.IsFalse(qcAlgorithm.Securities.ContainsKey(option.Symbol.Underlying));
            Assert.IsFalse(qcAlgorithm.Securities.ContainsKey(option2.Symbol.Underlying));
            qcAlgorithm.OnEndOfTimeStep();
            var data = qcAlgorithm.Securities[testHistoryProvider.underlyingSymbol].GetLastData();
            var data2 = qcAlgorithm.Securities[testHistoryProvider.underlyingSymbol2].GetLastData();
            Assert.IsNotNull(data);
            Assert.IsNotNull(data2);
            Assert.AreEqual(data.Price, 2);
            Assert.AreEqual(data2.Price, 3);
        }

        [Test, Parallelizable(ParallelScope.Self)]
        public void OnEndOfTimeStepDoesNotThrowWhenSeedsSameUnderlyingForTwoSecurities()
        {
            var qcAlgorithm = new QCAlgorithm();
            qcAlgorithm.SubscriptionManager.SetDataManager(new DataManagerStub(qcAlgorithm, new MockDataFeed()));
            qcAlgorithm.SetLiveMode(true);
            var testHistoryProvider = new TestHistoryProvider();
            qcAlgorithm.HistoryProvider = testHistoryProvider;
            var option = qcAlgorithm.AddOption(testHistoryProvider.underlyingSymbol);

            var symbol = Symbol.CreateOption(testHistoryProvider.underlyingSymbol, Market.USA, OptionStyle.American,
                OptionRight.Call, 1, new DateTime(2015, 12, 24));
            var symbol2 = Symbol.CreateOption(testHistoryProvider.underlyingSymbol, Market.USA, OptionStyle.American,
                OptionRight.Put, 1, new DateTime(2015, 12, 24));

            var optionContract = qcAlgorithm.AddOptionContract(symbol);
            var optionContract2 = qcAlgorithm.AddOptionContract(symbol2);

            qcAlgorithm.OnEndOfTimeStep();
            var data = qcAlgorithm.Securities[testHistoryProvider.underlyingSymbol].GetLastData();
            Assert.AreEqual(testHistoryProvider.LastResolutionRequest, Resolution.Minute);
            Assert.IsNotNull(data);
            Assert.AreEqual(data.Price, 2);
        }

        [Test]
        public void AddOptionWithUnderlyingFuture()
        {
            // Adds an option containing a Future as its underlying Symbol.
            // This is an essential step in enabling custom derivatives
            // based on any asset class provided to Option. This test
            // checks the ability to create Future Options.
            var algo = new QCAlgorithm();
            algo.SubscriptionManager.SetDataManager(new DataManagerStub(algo));

            var underlying = algo.AddFuture("ES", Resolution.Minute, Market.CME);
            underlying.SetFilter(0, 365);

            var futureOption = algo.AddOption(underlying.Symbol, Resolution.Minute);

            Assert.IsTrue(futureOption.Symbol.HasUnderlying);
            Assert.AreEqual(underlying.Symbol, futureOption.Symbol.Underlying);
        }

        [Test]
        public void AddFutureOptionContractNonEquityOption()
        {
            // Adds an option contract containing an underlying future contract.
            // We test to make sure that the security returned is a specific option
            // contract and with the future as the underlying.
            var algo = new QCAlgorithm();
            algo.SubscriptionManager.SetDataManager(new DataManagerStub(algo));

            var underlying = algo.AddFutureContract(
                Symbol.CreateFuture("ES", Market.CME, new DateTime(2021, 3, 19)),
                Resolution.Minute);

            var futureOptionContract = algo.AddFutureOptionContract(
                Symbol.CreateOption(underlying.Symbol, Market.CME, OptionStyle.American, OptionRight.Call, 2550m, new DateTime(2021, 3, 19)),
                Resolution.Minute);

            Assert.AreEqual(underlying.Symbol, futureOptionContract.Symbol.Underlying);
            Assert.AreEqual(underlying, futureOptionContract.Underlying);
            Assert.IsFalse(underlying.Symbol.IsCanonical());
            Assert.IsFalse(futureOptionContract.Symbol.IsCanonical());
        }

        [Test]
        public void AddFutureOptionAddsUniverseSelectionModel()
        {
            var algo = new QCAlgorithm();
            algo.SubscriptionManager.SetDataManager(new DataManagerStub(algo));

            var underlying = algo.AddFuture("ES", Resolution.Minute, Market.CME);
            underlying.SetFilter(0, 365);

            algo.AddFutureOption(underlying.Symbol, _ => _);
            Assert.IsTrue(algo.UniverseSelection is OptionChainedUniverseSelectionModel);
        }

        [Test]
        public void PythonCustomDataTypes_AreAddedToSubscriptions_Successfully()
        {
            var qcAlgorithm = new AlgorithmPythonWrapper("Test_CustomDataAlgorithm");
            qcAlgorithm.SubscriptionManager.SetDataManager(new DataManagerStub(qcAlgorithm));

            // Initialize contains the statements:
            // self.AddData(Nifty, "NIFTY")
            // self.AddData(QuandlFuture, "SCF/CME_CL1_ON", Resolution.Daily)
            qcAlgorithm.Initialize();

            var niftySubscription = qcAlgorithm.SubscriptionManager.Subscriptions.FirstOrDefault(x => x.Symbol.Value == "NIFTY");
            Assert.IsNotNull(niftySubscription);

            var niftyFactory = (BaseData)ObjectActivator.GetActivator(niftySubscription.Type).Invoke(new object[] { niftySubscription.Type });
            Assert.DoesNotThrow(() => niftyFactory.GetSource(niftySubscription, DateTime.UtcNow, false));

            var quandlSubscription = qcAlgorithm.SubscriptionManager.Subscriptions.FirstOrDefault(x => x.Symbol.Value == "SCF/CME_CL1_ON");
            Assert.IsNotNull(quandlSubscription);

            var quandlFactory = (BaseData)ObjectActivator.GetActivator(quandlSubscription.Type).Invoke(new object[] { quandlSubscription.Type });
            Assert.DoesNotThrow(() => quandlFactory.GetSource(quandlSubscription, DateTime.UtcNow, false));
        }

        [Test]
        public void PythonCustomDataTypes_AreAddedToConsolidator_Successfully()
        {
            var qcAlgorithm = new AlgorithmPythonWrapper("Test_CustomDataAlgorithm");
            qcAlgorithm.SubscriptionManager.SetDataManager(new DataManagerStub(qcAlgorithm));

            // Initialize contains the statements:
            // self.AddData(Nifty, "NIFTY")
            // self.AddData(QuandlFuture, "SCF/CME_CL1_ON", Resolution.Daily)
            qcAlgorithm.Initialize();

            var niftyConsolidator = new DynamicDataConsolidator(TimeSpan.FromDays(2));
            Assert.DoesNotThrow(() => qcAlgorithm.SubscriptionManager.AddConsolidator("NIFTY", niftyConsolidator));

            var quandlConsolidator = new DynamicDataConsolidator(TimeSpan.FromDays(2));
            Assert.DoesNotThrow(() => qcAlgorithm.SubscriptionManager.AddConsolidator("SCF/CME_CL1_ON", quandlConsolidator));
        }

        [Test]
        public void AddingInvalidDataTypeThrows()
        {
            var qcAlgorithm = new QCAlgorithm();
            qcAlgorithm.SubscriptionManager.SetDataManager(new DataManagerStub(qcAlgorithm));
            Assert.Throws<ArgumentException>(() => qcAlgorithm.AddData(typeof(double),
                "double",
                Resolution.Daily,
                DateTimeZone.Utc));
        }

        [Test]
        public void AppendsCustomDataTypeName_ToSecurityIdentifierSymbol()
        {
            const string ticker = "ticker";
            var algorithm = Algorithm();

            var security = algorithm.AddData<Quandl>(ticker);
            Assert.AreEqual(ticker.ToUpperInvariant(), security.Symbol.Value);
            Assert.AreEqual($"{ticker.ToUpperInvariant()}.{typeof(Quandl).Name}", security.Symbol.ID.Symbol);
            Assert.AreEqual(SecurityIdentifier.GenerateBaseSymbol(typeof(Quandl), ticker), security.Symbol.ID.Symbol);
        }

        [Test]
        public void RegistersSecurityIdentifierSymbol_AsTickerString_InSymbolCache()
        {
            var algorithm = Algorithm();

            Symbol cachedSymbol;
            var security = algorithm.AddData<Quandl>("ticker");
            var symbolCacheAlias = security.Symbol.ID.Symbol;

            Assert.IsTrue(SymbolCache.TryGetSymbol(symbolCacheAlias, out cachedSymbol));
            Assert.AreSame(security.Symbol, cachedSymbol);
        }

        [Test]
        public void DoesNotCauseCollision_WhenRegisteringMultipleDifferentCustomDataTypes_WithSameTicker()
        {
            const string ticker = "ticker";
            var algorithm = Algorithm();

            var security1 = algorithm.AddData<Quandl>(ticker);
            var security2 = algorithm.AddData<Bitcoin>(ticker);

            var quandl = algorithm.Securities[security1.Symbol];
            Assert.AreSame(security1, quandl);

            var bitcoin = algorithm.Securities[security2.Symbol];
            Assert.AreSame(security2, bitcoin);

            Assert.AreNotSame(quandl, bitcoin);
        }

        private static SubscriptionDataConfig GetMatchingSubscription(Security security, Type type)
        {
            // find a subscription matchin the requested type with a higher resolution than requested
            return (from sub in security.Subscriptions.OrderByDescending(s => s.Resolution)
                    where type.IsAssignableFrom(sub.Type)
                    select sub).FirstOrDefault();
        }

        private static QCAlgorithm Algorithm()
        {
            var algorithm = new QCAlgorithm();
            algorithm.SubscriptionManager.SetDataManager(new DataManagerStub(algorithm));
            return algorithm;
        }

        private class TestHistoryProvider : HistoryProviderBase
        {
            public string underlyingSymbol = "GOOG";
            public string underlyingSymbol2 = "AAPL";
            public override int DataPointCount { get; }
            public Resolution LastResolutionRequest;

            public override void Initialize(HistoryProviderInitializeParameters parameters)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<Slice> GetHistory(IEnumerable<HistoryRequest> requests, DateTimeZone sliceTimeZone)
            {
                var now = DateTime.UtcNow;
                LastResolutionRequest = requests.First().Resolution;
                var tradeBar1 = new TradeBar(now, underlyingSymbol, 1, 1, 1, 1, 1, TimeSpan.FromDays(1));
                var tradeBar2 = new TradeBar(now, underlyingSymbol2, 3, 3, 3, 3, 3, TimeSpan.FromDays(1));
                var slice1 = new Slice(now, new List<BaseData> { tradeBar1, tradeBar2 },
                                    new TradeBars(now), new QuoteBars(),
                                    new Ticks(), new OptionChains(),
                                    new FuturesChains(), new Splits(),
                                    new Dividends(now), new Delistings(),
                                    new SymbolChangedEvents());
                var tradeBar1_2 = new TradeBar(now, underlyingSymbol, 2, 2, 2, 2, 2, TimeSpan.FromDays(1));
                var slice2 = new Slice(now, new List<BaseData> { tradeBar1_2 },
                    new TradeBars(now), new QuoteBars(),
                    new Ticks(), new OptionChains(),
                    new FuturesChains(), new Splits(),
                    new Dividends(now), new Delistings(),
                    new SymbolChangedEvents());
                return new[] { slice1, slice2 };
            }
        }
    }
}
