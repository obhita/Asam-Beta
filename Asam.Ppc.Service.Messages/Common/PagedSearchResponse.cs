namespace Asam.Ppc.Service.Messages.Common
{
    using Agatha.Common;
    using System.Collections.Generic;

    public class PagedSearchResponse<TDto> : Response
    {
        public IEnumerable<TDto> Results { get; set; }
        public int TotalCount { get; set; }
    }
}
