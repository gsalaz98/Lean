using ProtoBuf;
using ProtoBuf.Meta;
using QuantConnect;
using QuantConnect.Algorithm;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace QuantConnect.Interop
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
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

            RuntimeTypeModel.Default.Add(typeof(List<BaseData>), true);
            RuntimeTypeModel.Default.Add(typeof(List<TradeBar>), true);
            RuntimeTypeModel.Default.Add(typeof(List<QuoteBar>), true);
            RuntimeTypeModel.Default.Add(typeof(List<Tick>), true);
            for (var i = 0; i < 10; i++)
            {
                // https://stackoverflow.com/a/13743494
                RuntimeTypeModel.Default.CompileInPlace();
            }

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
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, slice.Values);
                var length = (ulong)ms.Length;

                fixed (byte* dataPtr = ms.ToArray())
                {
                    _unmanagedAlgorithm = InteropAlgorithmExtern.OnData(_unmanagedAlgorithm, ref _ptrs, dataPtr, length);
                }
            }
        }
    }
}
