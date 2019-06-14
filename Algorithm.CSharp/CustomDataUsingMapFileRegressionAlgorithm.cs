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
using QuantConnect.Data;
using QuantConnect.Interfaces;
using QuantConnect.Data.Market;
using QuantConnect.Util;
using System.Globalization;
using System.Threading;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Basic template algorithm simply initializes the date range and cash. This is a skeleton
    /// framework you can use for designing an algorithm.
    /// </summary>
    /// <meta name="tag" content="using data" />
    /// <meta name="tag" content="using quantconnect" />
    /// <meta name="tag" content="trading and orders" />
    public class CustomDataUsingMapFileRegressionAlgorithm: QCAlgorithm, IRegressionAlgorithmDefinition
    {
        public override void Initialize()
        {
            SetStartDate(2018, 1, 1);
            SetEndDate(2019, 5, 31);

            // KORS renamed to 
            var symbol = AddData<TestUSEquities>("CPRI", Resolution.Daily);
        }

        public override void OnData(Slice slice)
        {
        }
    }

    public class TestUSEquities : BaseData
    {
        // scale factor used in QC equity/forex data files
        private const decimal _scaleFactor = 1 / 10000m;

        private int _initialized;
        private decimal _open;
        private decimal _high;
        private decimal _low;

        /// <summary>
        /// Volume:
        /// </summary>
        public virtual decimal Volume { get; set; }

        /// <summary>
        /// Opening price of the bar: Defined as the price at the start of the time period.
        /// </summary>
        public virtual decimal Open
        {
            get { return _open; }
            set
            {
                Initialize(value);
                _open = value;
            }
        }

        /// <summary>
        /// High price of the TradeBar during the time period.
        /// </summary>
        public virtual decimal High
        {
            get { return _high; }
            set
            {
                Initialize(value);
                _high = value;
            }
        }

        /// <summary>
        /// Low price of the TradeBar during the time period.
        /// </summary>
        public virtual decimal Low
        {
            get { return _low; }
            set
            {
                Initialize(value);
                _low = value;
            }
        }

        /// <summary>
        /// Closing price of the TradeBar. Defined as the price at Start Time + TimeSpan.
        /// </summary>
        public virtual decimal Close
        {
            get { return Value; }
            set
            {
                Initialize(value);
                Value = value;
            }
        }

        /// <summary>
        /// The closing time of this bar, computed via the Time and Period
        /// </summary>
        public override DateTime EndTime
        {
            get { return Time + Period; }
            set { Period = value - Time; }
        }

        /// <summary>
        /// The period of this trade bar, (second, minute, daily, ect...)
        /// </summary>
        public virtual TimeSpan Period { get; set; }

        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            if (isLiveMode)
            {
                return new SubscriptionDataSource(string.Empty, SubscriptionTransportMedium.LocalFile);
            }

            var source = LeanData.GenerateZipFilePath(Globals.DataFolder, config.Symbol, date, config.Resolution, config.TickType);
            if (config.SecurityType == SecurityType.Option ||
                config.SecurityType == SecurityType.Future)
            {
                source += "#" + LeanData.GenerateZipEntryName(config.Symbol, date, config.Resolution, config.TickType);
            }
            return new SubscriptionDataSource(source, SubscriptionTransportMedium.LocalFile, FileFormat.Csv);
        }

        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            //Handle end of file:
            if (line == null)
            {
                return null;
            }

            if (isLiveMode)
            {
                return new TestUSEquities();
            }

            try
            {
                return ParseEquity(config, line, date);
            }
            catch
            {
                // if we couldn't parse it above return a default instance
                return new TestUSEquities { Symbol = config.Symbol, Period = config.Increment };
            }
        }

        private TestUSEquities ParseEquity(SubscriptionDataConfig config, string line, DateTime date)
        {
            var testEquity = new TestUSEquities();

            var csv = line.ToCsv(6);
            if (config.Resolution == Resolution.Daily || config.Resolution == Resolution.Hour)
            {
                // hourly and daily have different time format, and can use slow, robust c# parser.
                testEquity.Time = DateTime.ParseExact(csv[0], DateFormat.TwelveCharacter, CultureInfo.InvariantCulture).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }
            else
            {
                // Using custom "ToDecimal" conversion for speed on high resolution data.
                testEquity.Time = date.Date.AddMilliseconds(csv[0].ToInt32()).ConvertTo(config.DataTimeZone, config.ExchangeTimeZone);
            }

            testEquity.Open = csv[1].ToDecimal() * _scaleFactor;
            testEquity.High = csv[2].ToDecimal() * _scaleFactor;
            testEquity.Low = csv[3].ToDecimal() * _scaleFactor;
            testEquity.Close = csv[4].ToDecimal() * _scaleFactor;
            testEquity.Volume = csv[5].ToDecimal();

            return testEquity;
        }

        /// <summary>
        /// Initializes this bar with a first data point
        /// </summary>
        /// <param name="value">The seed value for this bar</param>
        private void Initialize(decimal value)
        {
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) == 0)
            {
                _open = value;
                _low = value;
                _high = value;
            }
        }
    }
}
