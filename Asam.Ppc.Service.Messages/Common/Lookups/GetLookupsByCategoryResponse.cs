using System.Collections.Generic;
using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Common.Lookups
{
    public class GetLookupsByCategoryResponse : Response
    {
        public GetLookupsByCategoryResponse()
        {
            Lookups = new List<LookupDto>();
        }

        public IList<LookupDto> Lookups { get; set; }

        public string Category { get; set; }
    }
}