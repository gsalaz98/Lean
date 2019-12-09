﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Report
{
    public class Crisis
    {
        /// <summary>
        /// Crisis events and pre-defined values
        /// </summary>
        public readonly static Dictionary<CrisisEvent, Crisis> Events = new Dictionary<CrisisEvent, Crisis>
        {
            {CrisisEvent.GlobalFinancialCrisis, new Crisis("Global Financial Crisis", new DateTime(2007, 10, 1), new DateTime(2011, 12, 1))},
            {CrisisEvent.FlashCrash, new Crisis("Flash Crash", new DateTime(2010, 5, 5), new DateTime(2010, 5, 10))},
            {CrisisEvent.USDowngradeEuropeanDebt, new Crisis("U.S. Downgrade / European Debt Crisis", new DateTime(2011, 8, 5), new DateTime(2011, 9, 1))},
            {CrisisEvent.EurozoneSeptember2012, new Crisis("ECB IR Event 2012", new DateTime(2012, 9, 5), new DateTime(2012, 10, 12))},
            {CrisisEvent.EurozoneOctober2014, new Crisis("European Debt Crisis Oct. 2014", new DateTime(2014, 10, 1), new DateTime(2014, 10, 29))},
            {CrisisEvent.MarketSellOff2015, new Crisis("Market Sell-Off 2015", new DateTime(2015, 8, 10), new DateTime(2015, 10, 10))},
            {CrisisEvent.Recovery, new Crisis("Recovery", new DateTime(2010, 1, 1), new DateTime(2012, 10, 1))},
            {CrisisEvent.NewNormal, new Crisis("New Normal", new DateTime(2014, 1, 1), new DateTime(2019, 1, 1))}
        };

        /// <summary>
        /// Start of the crisis event
        /// </summary>
        public DateTime Start { get; private set; }

        /// <summary>
        /// End of the crisis event
        /// </summary>
        public DateTime End { get; private set; }

        /// <summary>
        /// Name of the crisis
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Creates a new crisis instance with the given name and start/end date.
        /// </summary>
        /// <param name="name">Name of the crisis</param>
        /// <param name="start">Start date of the crisis</param>
        /// <param name="end">End date of the crisis</param>
        public Crisis(string name, DateTime start, DateTime end)
        {
            Name = name;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Returns a pre-defined crisis event
        /// </summary>
        /// <param name="crisisEvent">Crisis Event</param>
        /// <returns>Pre-defined crisis event</returns>
        public static Crisis FromCrisis(CrisisEvent crisisEvent)
        {
            return Events[crisisEvent];
        }

        /// <summary>
        /// Converts instance to string using the dates in the instance as start/end dates
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(Start, End);
        }

        /// <summary>
        /// Converts instance to string using the provided dates
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <returns></returns>
        public string ToString(DateTime start, DateTime end)
        {
            if (Name.ToLowerInvariant().Contains("crisis"))
            {
                return $"{Name} {start:MMM yyyy} - {end:MMM yyyy}";
            }

            return $"Crisis {Name} {start:MMM yyyy} - {end:MMM yyyy}";
        }
    }
}
