using FlatSharp;
using QuantConnect;
using QuantConnect.Algorithm;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace QuantConnect.Interop
{
    public unsafe class InteropAlgorithm : QCAlgorithm
    {
        /// <summary>
        /// Handle to the unmanaged algorithm instance.
        /// </summary>
        /// <remarks>
        /// To setup your own unmanaged algorithm, create a static function
        /// that allocates an instance of your algorithm class/object/type
        /// and leak the memory if possible. Return the pointer of your type
        /// and C# will provide it to other extern functions you've defined
        /// so that you can manage algorithm state across the P/Invoke boundary.
        /// </remarks>
        private IntPtr _unmanagedAlgorithm;
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private InteropDelegates _delegates;
        private InteropFunctionPointers _ptrs;

        /// <summary>
        /// Initializes the unmanaged algorithm
        /// </summary>
        public InteropAlgorithm() : base()
        {
            _delegates = new InteropDelegates();
            _ptrs = new InteropFunctionPointers
            {
                SetStartDate = SetStartDate,
                SetEndDate = SetEndDate,
                AddEquity = (ticker, res) => AddEquity(ticker, (Resolution)res),
                History = (symbol, periods, res) => History(symbol, periods, (Resolution)res)
            };

            FlatBufferSerializer.Default.Compile<BaseDataCollection>();
            FlatBufferSerializer.Default.Compile<TradeBar>();
            FlatBufferSerializer.Default.Compile<Tick>();

            _unmanagedAlgorithm = InteropAlgorithmExtern.init();
            if (_unmanagedAlgorithm == IntPtr.Zero)
            {
                throw new NullReferenceException("Unmanaged algorithm returned null pointer");
            }
        }

        public override void Initialize()
        {
            _unmanagedAlgorithm = InteropAlgorithmExtern.Initialize(_unmanagedAlgorithm, ref _ptrs);
        }

        /// <remarks>
        /// Use the underlying byte array in a "fixed" context to pass a pointer for the data
        /// to the unmanaged algorithm. This way, we're guaranteed that we won't leak
        /// the byte's memory and that it will be safely managed by the GC.
        ///
        /// Additionally, there is some performance gains to be had by not copying the
        /// entire byte array over the P/Invoke boundary.
        /// </remarks>
        public unsafe override void OnData(Slice slice)
        {
            //var tbs = slice.Get<Data.Market.TradeBar>().Values.Select(x => new TradeBar()
            //{
            //    Open = (double)x.Open,
            //    High = (double)x.High,
            //    Low = (double)x.Low,
            //    Close = (double)x.Close,
            //    Volume = (double)x.Volume,
            //    DataType = (global::MarketDataType)(int)x.DataType,
            //    IsFillForward = x.IsFillForward,
            //    Period = x.Period.Ticks * 100,
            //    Time = x.Time.Subtract(_epoch).Ticks * 100,
            //    EndTime = x.EndTime.Subtract(_epoch).Ticks * 100,
            //    Symbol = GenerateInteropSymbol(x.Symbol),
            //    Value = (double)x.Value
            //}).ToList();

            //var ticks = slice.Get<Data.Market.Tick>().Values.Select(x => new Tick
            //{
            //    AskPrice = (double)x.AskPrice,
            //    BidPrice = (double)x.BidPrice,
            //    AskSize = (double)x.AskSize,
            //    BidSize = (double)x.BidSize,
            //    DataType = (global::MarketDataType)(int)x.DataType,
            //    EndTime = x.EndTime.Subtract(_epoch).Ticks * 100,
            //    Exchange = x.Exchange,
            //    IsFillForward = x.IsFillForward,
            //    Quantity = (double)x.Quantity,
            //    SaleCondition = x.SaleCondition,
            //    Suspicious = x.Suspicious,
            //    Symbol = GenerateInteropSymbol(x.Symbol),
            //    TickType = (global::TickType)(int)x.TickType,
            //    Time = x.Time.Subtract(_epoch).Ticks * 100,
            //    Value = (double)x.Value
            //}).ToList();

            var tradeBarsActual = slice.Get<Data.Market.TradeBar>().Values.ToList();
            var ticksActual = slice.Get<Data.Market.Tick>().Values.ToList();

            var tradeBars = new List<TradeBar>();
            var ticks = new List<Tick>();

            for (var i = 0; i < tradeBarsActual.Count; i++)
            {
                var tb = tradeBarsActual[i];
                tradeBars.Add(Unsafe.As<TradeBar>(tb));
            }
            for (var i = 0; i < ticksActual.Count; i++)
            {
                var tick = ticksActual[i];
                var newTick = Unsafe.As<Tick>(tick);
                Log($"{newTick.GetType().FullName}");
            }

            var collection = new BaseDataCollection()
            {
                TradeBars = tradeBars,
                Ticks = ticks
            };

            var maxSize = FlatBufferSerializer.Default.GetMaxSize(collection);
            Span<byte> data = new byte[maxSize];
            FlatBufferSerializer.Default.Serialize(collection, data);

            fixed (byte* dataPtr = data)
            {
                _unmanagedAlgorithm = InteropAlgorithmExtern.OnData(_unmanagedAlgorithm, ref _ptrs, dataPtr, (ulong)maxSize);
            }
        }

        private static global::SecurityIdentifier GenerateInteropSid(SecurityIdentifier sid)
        {
            return new global::SecurityIdentifier
            {
                SecurityType = (global::SecurityType)(int)sid.SecurityType,
                _date = sid.Date.Subtract(_epoch).Ticks * 100,
                _hashCode = sid.GetHashCode(),
                _optionRight = sid.SecurityType == SecurityType.Option ? (global::OptionRight)(int)sid.OptionRight : default,
                _optionStyle = sid.SecurityType == SecurityType.Option ? (global::OptionStyle)(int)sid.OptionStyle : default,
                _properties = DecodeBase36(sid.ToString().Split(' ')[1].Split('|')[0]),
                _strikePrice = sid.SecurityType == SecurityType.Option ? (double)sid.StrikePrice : default,
                _symbol = sid.Symbol,
                _underlying = !sid.HasUnderlying ? null : new SidBox()
                {
                    SecurityIdentifierInner = GenerateInteropSid(sid.Underlying)
                }
            };
        }

        private static QCSymbol GenerateInteropSymbol(Symbol symbol)
        {
            return symbol == null ? null : new QCSymbol()
            {
                HasUnderlying = symbol.HasUnderlying,
                ID = GenerateInteropSid(symbol.ID),
                SecurityType = (global::SecurityType)(int)symbol.SecurityType,
                Underlying = GenerateInteropSymbol(symbol.Underlying),
                Value = symbol.Value
            };
        }

        /// <summary>
        /// Converts an upper case alpha numeric string into a long
        /// </summary>
        private static ulong DecodeBase36(string symbol)
        {
            var result = 0ul;
            var baseValue = 1ul;
            for (var i = symbol.Length - 1; i > -1; i--)
            {
                var c = symbol[i];

                // assumes alpha numeric upper case only strings
                var value = (uint)(c <= 57
                    ? c - '0'
                    : c - 'A' + 10);

                result += baseValue * value;
                baseValue *= 36;
            }

            return result;
        }
    }
}
