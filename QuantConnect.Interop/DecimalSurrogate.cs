using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Interop
{
    [ProtoContract]
    public class DecimalSurrogate
    {
        [ProtoMember(1)]
        public double value { get; set; }

        public static implicit operator decimal(DecimalSurrogate surrogate)
        {
            return surrogate == null ? default(decimal) : (decimal)surrogate.value;
        }

        public static implicit operator DecimalSurrogate(decimal value)
        {
            return new DecimalSurrogate
            {
                value = (double)value
            };
        }
    }
}
