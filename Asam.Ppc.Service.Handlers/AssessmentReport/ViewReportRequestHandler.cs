using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.Scoring.ReportModule;
using Asam.Ppc.Domain.Scoring.ScoringModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.AssessmentReport;

namespace Asam.Ppc.Service.Handlers.AssessmentReport
{
    using System.Collections.Generic;

    public class ViewReportRequestHandler : ServiceRequestHandler<ViewReportRequest, FileStreamResponse>
    {
        private readonly IAssessmentRepository assessmentRepository;
        private readonly IAssessmentScoreRepository assessmentScoreRepository;
        private readonly IReportingEngine reportingEngine;

        public ViewReportRequestHandler (IAssessmentRepository assessmentRepository, IAssessmentScoreRepository assessmentScoreRepository, IReportingEngine reportingEngine )
        {
            this.assessmentRepository = assessmentRepository;
            this.assessmentScoreRepository = assessmentScoreRepository;
            this.reportingEngine = reportingEngine;
        }

        protected override void Handle ( ViewReportRequest request, FileStreamResponse response )
        { 
            var assessment = assessmentRepository.GetByKey(request.AssessmentKey);
            var assessmentScore = assessmentScoreRepository.GetAssessmentScoreByAssessment ( assessment );
            var assessmentReport = reportingEngine.GenerateAssessmentReportData ( assessment, assessmentScore );
            assessmentReport.ReportInfo.InterviewerName = assessmentScore.UserName;
            assessmentReport.ReportInfo.AppendixFilePath = request.AppendixFilePath;
            response.FileStream = reportingEngine.GenerateDocumentUsingAsamDocGenerator ( assessmentReport, request.ReportTempalteFilePath);
        }
    }
}
