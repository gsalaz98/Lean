using NodaTime;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Interop
{
    [ProtoContract]
    public class BaseDataSurrogate
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        [ProtoMember(1)]
        public int utc_offset_hours { get; set; }

        [ProtoMember(2)]
        public int utc_offset_minutes { get; set; }

        // Nanosecond level-precision time
        [ProtoMember(3)]
        public long utc_time { get; set; }

        public static DateTime FromUnixEpochTimestampNanos(BaseDataSurrogate surrogate)
        {
            // 100 nanoseconds = 1 tick
            var ticks = surrogate.utc_time / 100;
            var time = _epoch.AddTicks(ticks);

            return time.ConvertToUtc(
                DateTimeZone.ForOffset(
                    Offset.FromHoursAndMinutes(surrogate.utc_offset_hours, surrogate.utc_offset_minutes)
                )
            );
        }

        /// <summary>
        /// Converts time to unix epoch seconds and UTC offsets
        /// </summary>
        /// <param name="time">Time in UTC</param>
        /// <returns></returns>
        public static BaseDataSurrogate ToUnixEpochTimestampNanos(DateTime time)
        {
            var utcTime = DateTime.SpecifyKind(time, DateTimeKind.Utc);

            return new BaseDataSurrogate
            {
                utc_time = utcTime.Subtract(_epoch).Ticks * 100
            };
        }

        public static implicit operator DateTime(BaseDataSurrogate surrogate)
        {
            return surrogate == null ?
                default(DateTime) :
                FromUnixEpochTimestampNanos(surrogate);
        }

        public static implicit operator BaseDataSurrogate(DateTime time)
        {
            return ToUnixEpochTimestampNanos(time);
        }
    }
}
