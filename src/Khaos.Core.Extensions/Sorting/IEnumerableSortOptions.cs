using System;
using System.Collections.Generic;
using System.Linq;

namespace Khaos.Core.Extensions.Sorting
{
    public interface IEnumerableSortOptions<TEntity, TSort> : ISortOptions<TSort>
        where TEntity : class
        where TSort : Enum
    {
        IOrderedEnumerable<TEntity> SortEnumerable(IEnumerable<TEntity> source);
    }
}
