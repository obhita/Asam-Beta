using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Core
{
    public class PatientSearchByKeywordRequest : Request
    {
        public string Keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
