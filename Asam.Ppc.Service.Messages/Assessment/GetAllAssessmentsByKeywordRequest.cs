using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class GetAllAssessmentsByKeywordRequest : Request
    {
        public string Keyword { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
