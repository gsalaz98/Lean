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
using QuantConnect.Configuration;
using QuantConnect.Data;
using QuantConnect.Data.Consolidators;
using QuantConnect.Data.Market;
using QuantConnect.ToolBox.CoarseUniverseGenerator;

namespace QuantConnect.ToolBox.RandomDataGenerator
{
    /// <summary>
    /// Fake data generator app. Generates symbols with the name "FAKE" as the base, followed by a number
    /// </summary>
    /// <remarks>
    /// This app should be used to generate benchmark data if you are developing on LEAN
    /// and don't have either fast internet connection to download lots of data, or you don't have
    /// a subscription to a data provider. The data generated is useful for running performance benchmarks.
    /// </remarks>
    public static class RandomDataGeneratorProgram
    {
        private static DateTime _fromDate;
        private static DateTime _toDate;

        private static SecurityType _marketType;
        private static string _market;
        private static string _density;
        private static Resolution _resolution;
        private static int _granularity;
        private static OptionRight _right;

        private static bool _includeCoarse;
        
        /// <summary>
        /// Creates random data using a gaussian random walk.
        /// </summary>
        /// <param name="fromDate">Starting date</param>
        /// <param name="toDate">Ending date</param>
        /// <param name="density">Either: sequential timestamps, or timestamps that skip around</param>
        /// <param name="resolution">Granularity of data. e.g. Minute, Second</param>
        /// <param name="instrument">Financial instrument</param>
        /// <param name="includeCoarse">Generate Daily resolution data and calls <see cref="CoarseUniverseGeneratorProgram.CoarseUniverseGenerator" /></param>
        /// <param name="market">Market name, such as USA, GDAX, Oanda, FXCM, etc.</param>
        /// <param name="right">Option right, e.g. call, put</param>
        /// <param name="assetCount">Number of fake assets to generate</param>
        public static void RandomDataGenerator(DateTime fromDate, DateTime toDate, string density, string resolution, string instrument, string includeCoarse, string market, string right, string assetCount)
        {
            var dataDirectory = Config.Get("data-directory", "../../../Data");

            _fromDate = fromDate;
            _toDate = toDate;
            _market = market;
            _density = density;
            _resolution = (Resolution)Enum.Parse(typeof(Resolution), resolution);
            _granularity = (int)_resolution.ToTimeSpan().TotalSeconds;
            _right = right == "call" ? OptionRight.Call : OptionRight.Put;
            _includeCoarse = includeCoarse == "yes" ? true : false;

            bool isTradeBar = false;
            bool isQuoteBar = false;
            bool isOpenInterest = false;

            if (Market.Encode(_market) == null)
            {
                Console.WriteLine("Error: Invalid market type.");
                Environment.Exit(1);
            }
            if (density != "sparse" && density != "dense")
            {
                Console.WriteLine("Error: Unknown option for \"density\". Valid values are: \"sparse, dense\"");
                Environment.Exit(1);
            }
            if (right != "call" && right != "put")
            {
                Console.WriteLine("Error: Argument \"right\" must be either \"call\" or \"put\"");
                Environment.Exit(1);
            }
            if (instrument == "option" && _resolution != Resolution.Minute)
            {
                Console.WriteLine("Error: Options currently only accepts \"Minute\" resolution");
                Environment.Exit(1);
            }
            if (includeCoarse != "yes" && includeCoarse != "no")
            {
                Console.WriteLine("Error: include-coarse must be either \"yes\" or \"no\"");
                Environment.Exit(1);
            }

            switch (instrument)
            {
                case "equity":
                    _marketType = SecurityType.Equity;
                    isTradeBar = true;
                    break;
                case "crypto":
                    _marketType = SecurityType.Crypto;
                    isTradeBar = true;
                    isQuoteBar = true;
                    break;
                case "forex":
                    _marketType = SecurityType.Forex;
                    isQuoteBar = true;
                    break;
                case "cfd":
                    _marketType = SecurityType.Cfd;
                    isQuoteBar = true;
                    break;
                case "future":
                    _marketType = SecurityType.Future;
                    isTradeBar = true;
                    isQuoteBar = true;
                    isOpenInterest = true;
                    break;
                case "option":
                    _marketType = SecurityType.Option;
                    isTradeBar = true;
                    isQuoteBar = true;
                    isOpenInterest = true;
                    break;
                default:
                    Console.WriteLine("Invalid instrument specified. Valid instruments are: --instrument=equity,forex,cfd,future,option");
                    Environment.Exit(1);
                    break;
            }

            var symbols = CreateFakeSymbolString(assetCount.ToInt32());
            var dateTimeEnumerable = CreateDateTimeDensityEnumerable(_density);

            foreach (var fakeSymbol in symbols)
            {
                if (isTradeBar)
                {
                    Symbol fakeSymbolObject = CreateSymbol(fakeSymbol, dateTimeEnumerable);
                    var tradeBarData = TickGenerator(fakeSymbolObject, TickType.Trade, dateTimeEnumerable);

                    var consolidatedData = new List<BaseData>();
                    var barConsolidator = TradeBarConsolidator.FromResolution(Resolution.Daily);
                    // Append consolidated TradeBars into a List so that we can write it to disk
                    barConsolidator.DataConsolidated += (sender, bar) =>
                    {
                        consolidatedData.Add(bar);
                    };

                    var writer = new LeanDataWriter(_resolution, fakeSymbolObject, dataDirectory, TickType.Trade);
                    writer.Write(tradeBarData);

                    // Converts TradeBars to Daily resolution using TradeBarConsolidator
                    if (_includeCoarse && _marketType == SecurityType.Equity)
                    {
                        tradeBarData.ToList().ForEach(x => barConsolidator.Update(x));

                        var consolidatorWriter = new LeanDataWriter(Resolution.Daily, fakeSymbolObject, dataDirectory, TickType.Trade);
                        consolidatorWriter.Write(consolidatedData);
                    }
                }
                if (isQuoteBar)
                {
                    var fakeSymbolObject = CreateSymbol(fakeSymbol, dateTimeEnumerable);
                    var quoteBarData = TickGenerator(fakeSymbolObject, TickType.Quote, dateTimeEnumerable);

                    var writer = new LeanDataWriter(_resolution, fakeSymbolObject, dataDirectory, TickType.Quote);
                    writer.Write(quoteBarData);
                }
                if (isOpenInterest)
                {
                    var fakeSymbolObject = CreateSymbol(fakeSymbol, dateTimeEnumerable);
                    var openInterestData = TickGenerator(fakeSymbolObject, TickType.OpenInterest, dateTimeEnumerable);

                    var writer = new LeanDataWriter(_resolution, fakeSymbolObject, dataDirectory, TickType.OpenInterest);
                    writer.Write(openInterestData);
                }
            }
            if (_includeCoarse && _marketType == SecurityType.Equity)
            {
                CoarseUniverseGeneratorProgram.CoarseUniverseGenerator();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetCount">Number of fake symbols to create</param>
        /// <returns>Fake symbols as <see cref="List{String}"/></returns>
        /// <remarks>Uses "FAKE" as the base symbol in order to avoid collisions with real symbols</remarks>
        private static IEnumerable<String> CreateFakeSymbolString(int assetCount)
        {
            for (int i = 0; i < assetCount; i++)
            {
                yield return "FAKE" + i.ToString();
            }
        }

        /// <summary>
        /// Creates a symbol object representing the selected financial instrument
        /// </summary>
        /// <param name="fakeSymbol">Fake symbol name</param>
        /// <param name="dateTimeEnumerable">Enumerable to determine expiration dates of futures and options contracts</param>
        /// <returns></returns>
        private static Symbol CreateSymbol(string fakeSymbol, List<DateTime> dateTimeEnumerable)
        {
            if (_marketType == SecurityType.Future)
            {
                return Symbol.CreateFuture(fakeSymbol, _market, dateTimeEnumerable[dateTimeEnumerable.Count - 1]);
            }
            else if (_marketType == SecurityType.Option)
            {
                return Symbol.CreateOption(fakeSymbol, _market, OptionStyle.American, _right, 50.0m, dateTimeEnumerable[dateTimeEnumerable.Count - 1]);
            }
            else
            {
                return Symbol.Create(fakeSymbol, _marketType, _market);
            }
        }
        /// <summary>
        /// Create fake data with the given density and resolution
        /// </summary>
        /// <param name="fromDate">Start date</param>
        /// <param name="toDate">Ending date</param>
        /// <param name="symbol">Symbol to generate TradeBars or QuoteBars for</param>
        /// <param name="resolution"></param>
        /// <returns>Enumerable of base data for the given symbol</returns>
        private static IEnumerable<BaseData> TickGenerator(Symbol symbol, TickType tickType, List<DateTime> dateTimeEnumerable)
        {
            var rand = new Random();
            decimal previousPrice = rand.Next(1, 1000);
            
            foreach (var currentTime in dateTimeEnumerable) {
                var bidOpenPrice = previousPrice;
                var bidClosePrice = previousPrice + (previousPrice * RandomNormal(0.10, rand.NextDouble() - rand.NextDouble()) * new decimal(0.01));
                var bidHighPrice = Math.Max(bidClosePrice, previousPrice + (previousPrice * Math.Abs(RandomNormal(0.10, rand.NextDouble() - rand.NextDouble()) * new decimal(0.01))));
                var bidLowPrice = Math.Min(bidClosePrice, previousPrice - (previousPrice * Math.Abs(RandomNormal(0.10, rand.NextDouble() - rand.NextDouble()) * new decimal(0.01))));

                var askOpenPrice = bidOpenPrice + (decimal)0.0001;
                var askClosePrice = bidClosePrice + (decimal)0.0001;
                var askHighPrice = bidHighPrice + (decimal)0.0001;
                var askLowPrice = bidLowPrice + (decimal)0.0001;

                var openPrice = bidOpenPrice;
                var closePrice = bidClosePrice;
                var highPrice = bidHighPrice;
                var lowPrice = bidLowPrice;

                // Catch bankruptcy edge cases
                if (bidClosePrice <= 0)
                {
                    closePrice = new decimal(0.0001);
                }
                if (bidLowPrice <= 0)
                {
                    lowPrice = new decimal(0.0001);
                }
                var volume = Math.Round(Math.Abs(RandomNormal((double)((decimal)10000.0 * (closePrice - openPrice) / openPrice), rand.Next(100, 100000) * rand.NextDouble())));
                previousPrice = closePrice;

                if (tickType == TickType.Trade)
                {
                    yield return new TradeBar()
                    {
                        Time = currentTime,
                        Symbol = symbol,
                        Open = openPrice,
                        High = highPrice,
                        Low = lowPrice,
                        Close = closePrice,
                        Volume = volume,
                        Value = closePrice,
                        DataType = MarketDataType.TradeBar,
                        EndTime = currentTime.AddSeconds(_granularity)
                    };
                }
                if (tickType == TickType.Quote)
                {
                    yield return new QuoteBar()
                    {
                        Symbol = symbol,
                        Time = currentTime,
                        Bid = new Bar(bidOpenPrice, bidHighPrice, bidLowPrice, bidClosePrice),
                        Ask = new Bar(askOpenPrice, askHighPrice, askLowPrice, askClosePrice),
                        LastBidSize = rand.Next(1, 1000),
                        LastAskSize = rand.Next(1, 1000),
                        Period = TimeSpan.FromSeconds(_granularity),
                        DataType = MarketDataType.QuoteBar,
                    };
                }
                if (tickType == TickType.OpenInterest)
                {
                    yield return new OpenInterest()
                    {
                        Value = volume,
                        Time = currentTime,
                        Symbol = symbol,
                    };
                }
            }
        }

        /// <summary>
        /// Creates enumerable that allows <see cref="TickGenerator"/> to keep consistent <see cref="DateTime"/>
        /// entries for <see cref="TradeBar"/>, <see cref="QuoteBar"/>, and <see cref="OpenInterest"/> for the same asset.
        /// </summary>
        /// <param name="density"></param>
        /// <returns>List of DateTimes that keeps TradeBars, QuoteBars, and OpenInterest bars grouped together</returns>
        private static List<DateTime> CreateDateTimeDensityEnumerable(string density)
        {
            var dateEnumerable = new List<DateTime>();
            var currentDate = _fromDate;
            var rand = new Random();

            while (currentDate < _toDate)
            {
                dateEnumerable.Add(currentDate);

                if (density == "dense")
                {
                    currentDate = currentDate.Add(new TimeSpan(0, 0, _granularity));
                }
                else
                {
                    currentDate = currentDate.Add(new TimeSpan(0, 0, _granularity * rand.Next(1, 20)));
                }
            }

            return dateEnumerable;
        }
        /// <summary>
        /// Creates a normally distributed random number using Box-Muller transformation.
        /// </summary>
        /// <param name="sigma">Standard deviation</param>
        /// <param name="mu">Mean of distribution</param>
        /// <returns></returns>
        private static decimal RandomNormal(double sigma, double mu)
        {
            var rand = new Random();

            var x1 = 1.0 - rand.NextDouble();
            var x2 = 1.0 - rand.NextDouble();

            double z1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Sin(2 * Math.PI * x2);

            return new decimal(mu + z1 * sigma);
        }
    }
}
