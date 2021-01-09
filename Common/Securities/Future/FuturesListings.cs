using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantConnect.Securities.Future
{
    public static class FuturesListings
    {
        private static readonly Symbol _zb = Symbol.Create("ZB", SecurityType.Future, Market.CBOT);
        private static readonly Symbol _zc = Symbol.Create("ZC", SecurityType.Future, Market.CBOT);
        private static readonly Symbol _zs = Symbol.Create("ZS", SecurityType.Future, Market.CBOT);
        private static readonly Symbol _zt = Symbol.Create("ZT", SecurityType.Future, Market.CBOT);
        private static readonly Symbol _zw = Symbol.Create("ZW", SecurityType.Future, Market.CBOT);

        private static Dictionary<string, Func<DateTime, Symbol[]>> _futuresListingRules = new Dictionary<string, Func<DateTime, Symbol[]>>
        {
            { "ZB", t => QuarterlyContracts(_zb, t, 3) },
            { "ZC", t => MonthlyContractListings(
                _zc,
                t,
                12,
                new FuturesListingCycles(new[] { 3, 5, 9 }, 9),
                new FuturesListingCycles(new[] { 7, 12 }, 8)) },
            { "ZS", t => MonthlyContractListings(
                _zs,
                t,
                11,
                new FuturesListingCycles(new[] { 1, 3, 5, 8, 9 }, 15),
                new FuturesListingCycles(new[] { 7, 11 }, 8)) },
            { "ZT", t => QuarterlyContracts(_zt, t, 3) },
            { "ZW", t => MonthlyContractListings(
                _zw,
                t,
                7,
                new FuturesListingCycles(new[] { 3, 5, 7, 9, 12 }, 15)) }
        };

        public static Symbol[] ListedContracts(string futureTicker, DateTime lookupTime)
        {
            if (!_futuresListingRules.ContainsKey(futureTicker))
            {
                // No entries found. This differs from entries being returned as an empty array, where
                // that would mean that no listings were found.
                return null;
            }

            return _futuresListingRules[futureTicker](lookupTime);
        }

        public static Symbol[] ListedContracts(Symbol canonicalFuture, DateTime lookupTime)
        {
            return ListedContracts(canonicalFuture.ID.Symbol, lookupTime);
        }

        public static Symbol[] QuarterlyContracts(Symbol canonicalFuture, DateTime time, int limit)
        {
            var contractMonth = new DateTime(time.Year, time.Month, 1);
            var futureExpiry = DateTime.MinValue;

            while (futureExpiry < time)
            {
                futureExpiry = FuturesExpiryFunctions.FuturesExpiryFunction(canonicalFuture)(contractMonth);
                contractMonth = contractMonth.AddMonths(1);
            }

            var futureDelta = FuturesExpiryUtilityFunctions.GetDeltaBetweenContractMonthAndContractExpiry(canonicalFuture.ID.Symbol, futureExpiry);
            var firstFutureContractMonth = futureExpiry.AddMonths(futureDelta);

            var quarterlyContracts = new DateTime[limit];
            var quarterlyContractMonth = (int)Math.Ceiling((double)firstFutureContractMonth.Month / 3) * 3;

            for (var i = 0; i < limit; i++)
            {
                quarterlyContracts[i] = firstFutureContractMonth.AddMonths(-firstFutureContractMonth.Month + quarterlyContractMonth);
                quarterlyContractMonth += 3;
            }

            return quarterlyContracts.Where(t => t >= time)
                .OrderBy(t => t)
                .Select(t => FuturesExpiryFunctions.FuturesExpiryFunction(canonicalFuture)(t))
                .Select(e => Symbol.CreateFuture(canonicalFuture.ID.Symbol, canonicalFuture.ID.Market, e))
                .ToArray();
        }

        public static Symbol[] MonthlyContractListings(
            Symbol canonicalFuture,
            DateTime time,
            int contractMonthForNewListings,
            params FuturesListingCycles[] futureListingCycles)
        {
            var listings = new List<DateTime>();
            var contractMonthForNewListingCycle = new DateTime(time.Year, contractMonthForNewListings, 1);

            var year = time.Year;
            if (time > FuturesExpiryFunctions.FuturesExpiryFunction(canonicalFuture)(contractMonthForNewListingCycle))
            {
                year += 1;
            }

            foreach (var listingCycle in futureListingCycles)
            {
                for (var i = 0; i < listingCycle.Limit / listingCycle.Cycle.Length; i++)
                {
                    foreach (var month in listingCycle.Cycle)
                    {
                        listings.Add(new DateTime(year + i, month, 1));
                    }
                }
            }

            return listings.Where(t => t >= time)
                .OrderBy(t => t)
                .Select(t => FuturesExpiryFunctions.FuturesExpiryFunction(canonicalFuture)(t))
                .Select(e => Symbol.CreateFuture(canonicalFuture.ID.Symbol, canonicalFuture.ID.Market, e))
                .ToArray();
        }

        public class FuturesListingCycles
        {
            public int[] Cycle { get; }
            public int Limit { get; }


            public FuturesListingCycles(int[] cycle, int limit)
            {
                Cycle = cycle;
                Limit = limit;
            }
        }
    }
}
