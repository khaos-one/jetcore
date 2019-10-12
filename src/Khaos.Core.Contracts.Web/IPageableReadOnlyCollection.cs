using System.Collections.Generic;

namespace Khaos.Core.Contracts.Web
{
    public interface IPageableReadOnlyCollection<T>
    {
        uint TotalCount { get; set; }
        IReadOnlyCollection<T> Items { get; set; }
    }
}