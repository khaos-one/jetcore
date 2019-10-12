using System.Collections;
using System.Collections.Generic;

namespace Khaos.Core.Contracts.Web
{
    public class PageableReadOnlyCollection<T>
        : IPageableReadOnlyCollection<T>, IReadOnlyCollection<T>
    {
        public uint TotalCount { get; set; }
        public IReadOnlyCollection<T> Items { get; set; }
        
        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => Items.Count;
    }
}