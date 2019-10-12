using System;
using System.Collections.Generic;
using System.Linq;

namespace Khaos.Core.Extensions.Sorting
{
    public static class SortOptionsEnumerableExtensions
    {
        public static IOrderedEnumerable<T> SortWithOptions<T, TSortType>(
            this IEnumerable<T> source,
            IEnumerableSortOptions<T, TSortType> options)
            where T : class
            where TSortType : Enum
        {
            Check.NotNull(source, nameof(source));
            Check.NotNull(options, nameof(options));

            return options.SortEnumerable(source);
        }

        public static IOrderedEnumerable<T> OrderByWithOrderDirection<T, TKey>(
            this IEnumerable<T> source,
            Func<T, TKey> keySelector,
            SortOptionsDirection direction)
        {
            Check.NotNull(source, nameof(source));
            Check.NotNull(keySelector, nameof(keySelector));

            switch (direction)
            {
                case SortOptionsDirection.Asc:
                    return source.OrderBy(keySelector);

                case SortOptionsDirection.Desc:
                    return source.OrderByDescending(keySelector);

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}