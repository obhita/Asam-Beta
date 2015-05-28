using System.Collections.Generic;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Assessment;
using Asam.Ppc.Service.Messages.Core;
using AutoMapper;

namespace Asam.Ppc.Service.Handlers.Core
{
    public class GetPatientAssessmentsGetRequestHandler : ServiceRequestHandler<GetPatientAssessmentsRequest,GetPatientAssessmentsResponse>
    {
        private readonly IAssessmentRepository _assessmentRepository;

        public GetPatientAssessmentsGetRequestHandler (IAssessmentRepository assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
        }

        protected override void Handle ( GetPatientAssessmentsRequest request, GetPatientAssessmentsResponse response )
        {
            int totalCount;
            var assessments = _assessmentRepository.GetPagedAssessmentsByPatientId ( request.PatientKey, request.PageIndex, request.PageSize, out totalCount );
            if (assessments != null)
            {
                var assessmentDtos =
                    Mapper.Map<IEnumerable<Domain.AssessmentModule.Assessment>, IEnumerable<AssessmentSummaryDto>>(
                        assessments);

                response.TotalCount = totalCount;
                response.Assessments = assessmentDtos;
            }
        }
    }
}
