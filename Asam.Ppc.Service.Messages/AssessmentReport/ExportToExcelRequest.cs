namespace Asam.Ppc.Service.Messages.AssessmentReport
{
    using Agatha.Common;

    public class ExportToExcelRequest : Request
    {
        public long AssessmentKey { get; set; }
        public bool GetScore { get; set; }
    }
}
