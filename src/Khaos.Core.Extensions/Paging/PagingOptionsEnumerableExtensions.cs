using System.Collections.Generic;
using System.Linq;

namespace Khaos.Core.Extensions.Paging
{
    public static class PagingOptionsEnumerableExtensions
    {
        public static IEnumerable<T> PageWithOptions<T>(this IEnumerable<T> source, IPagingOptions options)
        {
            Check.NotNull(source, nameof(source));
            Check.NotNull(options, nameof(options));

            var pageCount = (int) options.GetCurrentPageCount();
            return source.Skip((int) options.Page * pageCount).Take(pageCount);
        }
    }
}
