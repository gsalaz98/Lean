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
using System.Globalization;
using System.IO;
using System.Threading;
using QuantConnect.Data.Market;

namespace QuantConnect.Data.Custom
{
    /// <summary>
    /// A copy of the <see cref="TradeBar"/> class.
    /// DO NOT USE. This class is defined only for CustomDataUsingMapFileRegressionAlgorithm.
    /// We define it here instead of the QuantConnect.Algorithm.CSharp namespace in order to be able
    /// to add it to the list of supported mapfile custom data types.
    /// Added to <see cref="SubscriptionDataConfig.MapFileTypes"/> in order to enable support for map files.
    /// </summary>
    public class RegressionAlgorithmUSEquities: BaseData
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
            string source;
            if (config.Resolution == Resolution.Daily || config.Resolution == Resolution.Daily)
            {
                source = Path.Combine(
                    Globals.DataFolder,
                    "equity",
                    QuantConnect.Market.USA,
                    config.Resolution.ToLower(),
                    $"{config.Symbol.Value.ToLower()}.zip#{config.Symbol.Value.ToLower()}.csv");
            }
            else
            {
                source = Path.Combine(
                    Globals.DataFolder,
                    "equity",
                    QuantConnect.Market.USA,
                    config.Symbol.Value.ToLower(),
                    $"{date:yyyyMMdd}_trade.zip#{date:yyyyMMdd}_{config.Symbol.Value.ToLower()}_{config.Resolution.ToString().ToLower()}_trade.csv");
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
                return new RegressionAlgorithmUSEquities();
            }

            try
            {
                return ParseEquity(config, line, date);
            }
            catch
            {
                // if we couldn't parse it above return a default instance
                return new RegressionAlgorithmUSEquities { Symbol = config.Symbol, Period = config.Increment };
            }
        }

        /// <summary>
        /// Helper method to create a new equity based off data passed to the <see cref="Reader"/>
        /// </summary>
        /// <param name="config">Subscription configuration</param>
        /// <param name="line">Line of csv data</param>
        /// <param name="date">Date of the requested data</param>
        /// <returns><see cref="RegressionAlgorithmUSEquities"/> instance</returns>
        private RegressionAlgorithmUSEquities ParseEquity(SubscriptionDataConfig config, string line, DateTime date)
        {
            var testEquity = new RegressionAlgorithmUSEquities();

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