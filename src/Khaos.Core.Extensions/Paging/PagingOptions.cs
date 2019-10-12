namespace Khaos.Core.Extensions.Paging
{
    public class PagingOptions : IPagingOptions
    {
        public uint Page { get; set; }
        public uint? PageCount { get; set; }

        public uint MinPageCount => 1;
        public uint MaxPageCount => 100;
        public uint DefaultPageCount => 10;
    }
}