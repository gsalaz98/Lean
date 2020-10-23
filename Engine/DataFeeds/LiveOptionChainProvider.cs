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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Activation;
using System.Threading;
using Newtonsoft.Json;
using QuantConnect.Interfaces;
using QuantConnect.Logging;
using QuantConnect.Securities.Future;
using QuantConnect.Util;

namespace QuantConnect.Lean.Engine.DataFeeds
{
    /// <summary>
    /// An implementation of <see cref="IOptionChainProvider"/> that fetches the list of contracts
    /// from the Options Clearing Corporation (OCC) website
    /// </summary>
    public class LiveOptionChainProvider : IOptionChainProvider
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1);

        private readonly RateGate _rateGate = new RateGate(1, TimeSpan.FromSeconds(0.5));

        private const string CMESymbolReplace = "{{SYMBOL}}";
        private const string CMEProductCodeReplace = "{{PRODUCT_CODE}}";
        private const string CMEProductExpirationReplace = "{{PRODUCT_EXPIRATION}}";

        private const string CMEProductSlateURL = "https://www.cmegroup.com/CmeWS/mvc/ProductSlate/V2/List?pageNumber=1&sortAsc=false&sortField=rank&searchString=" + CMESymbolReplace + "&pageSize=5";
        private const string CMEOptionsCategoryListURL = "https://www.cmegroup.com/CmeWS/mvc/Options/Categories/List/" + CMEProductCodeReplace + "/G?optionTypeFilter=&_=";
        private const string CMEOptionChainURL = "https://www.cmegroup.com/CmeWS/mvc/Quotes/Option/" + CMEProductCodeReplace + "/G/" + CMEProductExpirationReplace + "/ALL?_=";

        private const int MaxDownloadAttempts = 5;

        /// <summary>
        /// Static constructor for the <see cref="LiveOptionChainProvider"/> class
        /// </summary>
        static LiveOptionChainProvider()
        {
            // The OCC website now requires at least TLS 1.1 for API requests.
            // NET 4.5.2 and below does not enable these more secure protocols by default, so we add them in here
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public IEnumerable<Symbol> GetOptionContractList(Symbol underlyingSymbol, DateTime date)
        {
            if (underlyingSymbol.SecurityType == SecurityType.Equity)
            {
                return GetEquityOptionContractList(underlyingSymbol, date);
            }
            if (underlyingSymbol.SecurityType == SecurityType.Future)
            {
                return GetFutureOptionContractList(underlyingSymbol, date);
            }

            throw new ArgumentException("Option's Underlying SecurityType is not supported. Supported types are: Equity, Future");
        }

        private IEnumerable<Symbol> GetFutureOptionContractList(Symbol futureContractSymbol, DateTime date)
        {
            var symbols = new List<Symbol>();
            var retries = 0;
            var maxRetries = 5;

            while (++retries <= maxRetries)
            {
                try
                {
                    var productResponse = _client.GetAsync(CMEProductSlateURL.Replace(CMESymbolReplace, futureContractSymbol.ID.Symbol))
                        .SynchronouslyAwaitTaskResult();

                    productResponse.EnsureSuccessStatusCode();

                    var productResults = JsonConvert.DeserializeObject<CMEProductSlateV2ListResponse>(productResponse.Content.ReadAsStringAsync()
                        .SynchronouslyAwaitTaskResult());

                    var futureProductId = productResults.Products.Where(p => p.Globex == futureContractSymbol.ID.Symbol && p.GlobexTraded && p.Cleared == "Futures")
                        .Select(p => p.Id)
                        .Single();

                    _rateGate.WaitToProceed();

                    var categoryListUrl = CMEOptionsCategoryListURL.Replace(CMEProductCodeReplace, futureProductId.ToStringInvariant())
                        + Math.Floor((DateTime.UtcNow - _epoch).TotalMilliseconds).ToStringInvariant();

                    var categoryListResponse = _client.GetAsync(categoryListUrl).SynchronouslyAwaitTaskResult();
                    categoryListResponse.EnsureSuccessStatusCode();

                    var categoryList = JsonConvert.DeserializeObject<Dictionary<int, CMEOptionsCategoryListEntry>>(categoryListResponse.Content
                        .ReadAsStringAsync()
                        .SynchronouslyAwaitTaskResult());

                    var optionProductId = categoryList
                        .Where(kvp => !kvp.Value.Daily && !kvp.Value.Weekly && !kvp.Value.Sto && kvp.Value.OptionType == "AME")
                        .Select(x => x.Key)
                        .FirstOrDefault();

                    if (optionProductId == default(int))
                    {
                        Log.Error($"LiveOptionChainProvider.GetFutureOptionContractList(): Found no matching future options for contract {futureContractSymbol}");
                        yield break;
                    }

                    var futureContractMonthCode = futureContractSymbol.Value[futureContractSymbol.Value.Length - 3].ToStringInvariant() + futureContractSymbol.Value[futureContractSymbol.Value.Length - 1].ToStringInvariant();
                    _rateGate.WaitToProceed();

                    var optionChainQuotesResponseResult = _client.GetAsync(CMEOptionChainURL.Replace(CMEProductCodeReplace, optionProductId.ToStringInvariant())
                        .Replace(CMEProductExpirationReplace, futureContractMonthCode)
                        + Math.Floor((DateTime.UtcNow - _epoch).TotalMilliseconds).ToStringInvariant());

                    optionChainQuotesResponseResult.Result.EnsureSuccessStatusCode();

                    var futureOptionChain = JsonConvert.DeserializeObject<CMEOptionChainQuotes>(optionChainQuotesResponseResult.Result.Content
                        .ReadAsStringAsync()
                        .SynchronouslyAwaitTaskResult());

                    foreach (var optionChainEntry in futureOptionChain.OptionContractQuotes)
                    {
                        symbols.Add(Symbol.CreateOption(
                            futureContractSymbol,
                            futureContractSymbol.ID.Market,
                            OptionStyle.American,
                            OptionRight.Call,
                            optionChainEntry.Call.StrikePrice,
                            futureContractSymbol.ID.Date));

                       symbols.Add(Symbol.CreateOption(
                           futureContractSymbol,
                           futureContractSymbol.ID.Market,
                           OptionStyle.American,
                           OptionRight.Put,
                           optionChainEntry.Call.StrikePrice,
                           futureContractSymbol.ID.Date));
                    }
                }
                catch (HttpRequestException err)
                {
                    if (retries != maxRetries)
                    {
                        Log.Error(err, $"Failed to retrieve futures options chain from CME, retrying ({retries} / {maxRetries})");
                        continue;
                    }

                    Log.Error(err, $"Failed to retrieve futures options chain from CME, returning empty result ({retries} / {retries})");
                }
            }

            foreach (var symbol in symbols)
            {
                yield return symbol;
            }
        }

        /// <summary>
        /// Gets the list of option contracts for a given underlying equity symbol
        /// </summary>
        /// <param name="symbol">The underlying symbol</param>
        /// <param name="date">The date for which to request the option chain (only used in backtesting)</param>
        /// <returns>The list of option contracts</returns>
        private IEnumerable<Symbol> GetEquityOptionContractList(Symbol symbol, DateTime date)
        {
            var attempt = 1;
            IEnumerable<Symbol> contracts;

            while (true)
            {
                try
                {
                    Log.Trace($"LiveOptionChainProvider.GetOptionContractList(): Fetching option chain for {symbol.Value} [Attempt {attempt}]");

                    contracts = FindEquityOptionContracts(symbol.Value);
                    break;
                }
                catch (WebException exception)
                {
                    Log.Error(exception);

                    if (++attempt > MaxDownloadAttempts)
                    {
                        throw;
                    }

                    Thread.Sleep(1000);
                }
            }

            return contracts;
        }

        /// <summary>
        /// Retrieve the list of option contracts for an underlying symbol from the OCC website
        /// </summary>
        private static IEnumerable<Symbol> FindEquityOptionContracts(string underlyingSymbol)
        {
            var symbols = new List<Symbol>();

            using (var client = new WebClient())
            {
                // use QC url to bypass TLS issues with Mono pre-4.8 version
                var url = "https://www.quantconnect.com/api/v2/theocc/series-search?symbolType=U&symbol=" + underlyingSymbol;

                // download the text file
                var fileContent = client.DownloadString(url);

                // read the lines, skipping the headers
                var lines = fileContent.Split(new[] { "\r\n" }, StringSplitOptions.None).Skip(7);

                // parse the lines, creating the Lean option symbols
                foreach (var line in lines)
                {
                    var fields = line.Split('\t');

                    var ticker = fields[0].Trim();
                    if (ticker != underlyingSymbol)
                        continue;

                    var expiryDate = new DateTime(fields[2].ToInt32(), fields[3].ToInt32(), fields[4].ToInt32());
                    var strike = (fields[5] + "." + fields[6]).ToDecimal();

                    if (fields[7].Contains("C"))
                    {
                        symbols.Add(Symbol.CreateOption(underlyingSymbol, Market.USA, OptionStyle.American, OptionRight.Call, strike, expiryDate));
                    }

                    if (fields[7].Contains("P"))
                    {
                        symbols.Add(Symbol.CreateOption(underlyingSymbol, Market.USA, OptionStyle.American, OptionRight.Put, strike, expiryDate));
                    }
                }
            }

            return symbols;
        }
    }
}
