using System;
using System.Collections.Generic;
using System.Linq;

namespace Khaos.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsNear(this DateTime dt1, DateTime dt2, TimeSpan? epsilon = null)
        {
            if (epsilon == null)
            {
                epsilon = TimeSpan.FromMilliseconds(100);
            }

            return dt1 - epsilon <= dt2 && dt1 + epsilon >= dt2;
        }

        public static DateTime Trim(this DateTime dt, DateTimePrecision precision)
        {
            switch (precision)
            {
                case DateTimePrecision.Seconds:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Kind);
                
                case DateTimePrecision.Minutes:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, dt.Kind);
                
                case DateTimePrecision.Hours:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, 0, dt.Kind);
                
                case DateTimePrecision.Days:
                    return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind);
                
                case DateTimePrecision.Months:
                    return new DateTime(dt.Year, dt.Month, 0, 0, 0, 0, 0, dt.Kind);
                
                case DateTimePrecision.Years:
                    return new DateTime(dt.Year, dt.Kind);
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(precision));
            }
        }

        public static IEnumerable<DateTime> EnumerateAllHoursTo(
            this DateTime start, DateTime end, 
            bool includeLastFraction = false, double lastFractionThreshold = 0)
        {
            if (end < start)
            {
                throw new ArgumentException("Start date is greater than the end date.", nameof(end));
            }

            var delta = end - start;
            var roundHours = (int) Math.Truncate(delta.TotalHours);

            if (includeLastFraction)
            {
                var fraction = delta.TotalHours - roundHours;

                if (fraction > lastFractionThreshold)
                {
                    roundHours += 1;
                }
            }

            return Enumerable.Range(0, roundHours).Select(hour => start + TimeSpan.FromHours(hour));
        }
    }
}
