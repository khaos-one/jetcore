namespace Khaos.Core.Extensions.Paging
{
    public interface IPagingOptions
    {
        uint Page { get; set; }
        uint? PageCount { get; set; }

        uint MinPageCount { get; }
        uint MaxPageCount { get; }
        uint DefaultPageCount { get; }
    }
}