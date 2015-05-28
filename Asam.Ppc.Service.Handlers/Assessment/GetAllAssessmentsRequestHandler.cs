using System.Collections.Generic;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Assessment;
using AutoMapper;

namespace Asam.Ppc.Service.Handlers.Assessment
{
    public class GetAllAssessmentsRequestHandler : ServiceRequestHandler<GetAllAssessmentsByKeywordRequest, GetAllAssessmentsByKeywordResponse>
    {
        private readonly IAssessmentRepository _assessmentRepository;

        public GetAllAssessmentsRequestHandler ( IAssessmentRepository assessmentRepository )
        {
            _assessmentRepository = assessmentRepository;
        }

        protected override void Handle ( GetAllAssessmentsByKeywordRequest request, GetAllAssessmentsByKeywordResponse response )
        {
            int totalCount;
            var assessments = _assessmentRepository.GetAllAssessmentsByKeyword ( request.Keyword,
                                                                                 request.PageIndex,
                                                                                 request.PageSize,
                                                                                 out totalCount );

            var assessmentDtos = Mapper.Map<List<Domain.AssessmentModule.Assessment>, List<AssessmentSummaryDto>>(assessments);

            response.TotalCount = totalCount;
            response.Assessments = assessmentDtos;
        }
    }
}
