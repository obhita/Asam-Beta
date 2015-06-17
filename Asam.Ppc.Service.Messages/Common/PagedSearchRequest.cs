namespace Asam.Ppc.Service.Messages.Common
{
    using Agatha.Common;

    public class PagedSearchRequest<TDto> : Request
    {
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
