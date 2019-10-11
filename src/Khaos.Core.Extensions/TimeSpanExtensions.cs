using System;

namespace Khaos.Core.Extensions
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Times(this TimeSpan span, float factor)
        {
            return TimeSpan.FromTicks((long) Math.Round(span.Ticks * factor));
        }
    }
}
