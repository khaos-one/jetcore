using System;

namespace Khaos.Core.Extensions.Paging
{
    public static class PagingOptionsExtensions
    {
        public static uint GetCurrentPageCount(this IPagingOptions options)
        {
            var pageCount = options.PageCount ?? options.DefaultPageCount;
            return Math.Min(Math.Max(pageCount, options.MinPageCount), options.MaxPageCount);
        }
    }
}
