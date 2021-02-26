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
using QuantConnect.Interfaces;
using QuantConnect.Orders;

namespace QuantConnect.Lean.Engine.Results
{
    public class CapacityEstimate
    {
        private readonly IAlgorithm _algorithm;
        private readonly Dictionary<Symbol, SymbolCapacity> _capacityBySymbol;
        private List<SymbolCapacity> _monitoredSymbolCapacity;
        private HashSet<SymbolCapacity> _monitoredSymbolCapacitySet;
        private DateTime _nextSnapshotTime;
        private decimal _capacity;

        /// <summary>
        /// The total capacity of the strategy at a point in time
        /// </summary>
        public decimal Capacity
        {
            get
            {
                if (_algorithm.UtcTime > _nextSnapshotTime && _capacityBySymbol.Count != 0)
                {
                    _nextSnapshotTime = _algorithm.UtcTime.AddMonths(1);

                    var totalPortfolioValue = _algorithm.Portfolio.TotalPortfolioValue;
                    var totalSaleVolume = _capacityBySymbol.Values
                        .Sum(s => s.SaleVolume);

                    if (totalSaleVolume == 0 || totalPortfolioValue == 0)
                    {
                        return _capacity;
                    }

                    var smallestAsset = _capacityBySymbol.Values
                        .OrderBy(c => c.MarketCapacityDollarVolume)
                        .First();

                    var percentageOfSaleVolume = smallestAsset.SaleVolume / totalSaleVolume;
                    var percentageOfHoldings = smallestAsset.TotalHoldingsInDollars / totalPortfolioValue;

                    var scalingFactor = Math.Max(percentageOfSaleVolume, percentageOfHoldings);

                    _capacity = scalingFactor == 0
                        ? _capacity
                        : smallestAsset.MarketCapacityDollarVolume / scalingFactor;
                }

                return _capacity;
            }
        }

        /// <summary>
        /// Initializes an instance of the class.
        /// </summary>
        /// <param name="algorithm">Used to get data at the current time step and access the portfolio state</param>
        public CapacityEstimate(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
            _capacityBySymbol = new Dictionary<Symbol, SymbolCapacity>();
            _monitoredSymbolCapacity = new List<SymbolCapacity>();
            _monitoredSymbolCapacitySet = new HashSet<SymbolCapacity>();
        }

        /// <summary>
        /// Processes an order whenever it's encountered so that we can calculate the capacity
        /// </summary>
        /// <param name="order">Order to use to calculate capacity</param>
        public void OnOrderEvent(OrderEvent orderEvent)
        {
            SymbolCapacity symbolCapacity;
            if (!_capacityBySymbol.TryGetValue(orderEvent.Symbol, out symbolCapacity))
            {
                symbolCapacity = new SymbolCapacity(_algorithm, orderEvent.Symbol);
                _capacityBySymbol[orderEvent.Symbol] = symbolCapacity;
            }

            symbolCapacity.OnOrderEvent(orderEvent);
            if (_monitoredSymbolCapacitySet.Contains(symbolCapacity))
            {
                return;
            }

            _monitoredSymbolCapacity.Add(symbolCapacity);
            _monitoredSymbolCapacitySet.Add(symbolCapacity);
        }

        public void UpdateMarketCapacity()
        {
            for (var i = _monitoredSymbolCapacity.Count - 1; i >= 0; --i)
            {
                var capacity = _monitoredSymbolCapacity[i];
                if (capacity.UpdateMarketCapacity())
                {
                    _monitoredSymbolCapacity.RemoveAt(i);
                    _monitoredSymbolCapacitySet.Remove(capacity);
                }
            }
        }
    }
}
