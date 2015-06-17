using Agatha.Common;

namespace Asam.Ppc.Service.Messages.AssessmentReport
{
    public class ViewReportRequest : Request
    {
        public long AssessmentKey { get; set; }

        public string ReportTempalteFilePath { get; set; } //TODO: this is not currently used.

        public string AppendixFilePath { get; set; }

        public string InterviewerName { get; set; }
    }
}
