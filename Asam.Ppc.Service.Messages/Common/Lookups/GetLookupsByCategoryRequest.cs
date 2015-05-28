using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Common.Lookups
{
    // NOTE: to clear cache, use ICacheManager in Create/Change/Delete Lookup item handlers.
    [EnableServiceResponseCaching(Hours = 1)]
    [EnableClientResponseCaching(Hours = 4)]
    public class GetLookupsByCategoryRequest : Request
    {
        public string Category { get; set; }

        public bool IncludingInactiveItems { get; set; }
    }
}