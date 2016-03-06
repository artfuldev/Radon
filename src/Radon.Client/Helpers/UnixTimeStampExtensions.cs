using System;

namespace Radon.Client.Helpers
{
    /// <summary>
    /// Extensions for converting between different time representations
    /// </summary>
    public static class UnixTimestampExtensions
    { 
        // Unix Epoch is January 1, 1970 00:00 -0:00
        private const long unixEpochTicks = 621355968000000000;

        /// <summary>
        /// Convert a Unix tick to a <see cref="DateTimeOffset"/> with UTC offset
        /// </summary>
        /// <param name="unixTime">UTC tick</param>
        public static DateTimeOffset FromUnixTime(this long unixTime)
        {
            return new DateTimeOffset(unixTime * TimeSpan.TicksPerSecond + unixEpochTicks, TimeSpan.Zero);
        }
    }
}
