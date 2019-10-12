using System;

namespace Khaos.Core.Extensions.Sorting
{
    public interface ISortOptions<TSort>
        where TSort : Enum
    {
        TSort SortBy { get; set; }
        SortOptionsDirection? SortDirection { get; set; }
    }
}