using System.Collections.Generic;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Core;
using AutoMapper;

namespace Asam.Ppc.Service.Handlers.Core
{
    public class PatientSearchByKeywordRequestHandler : ServiceRequestHandler<PatientSearchByKeywordRequest,PatientSearchResponse>
    {
        private readonly IPatientRepository _patientRepository;

        public PatientSearchByKeywordRequestHandler (IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        protected override void Handle ( PatientSearchByKeywordRequest request, PatientSearchResponse response )
        {
            int totalCount;
            var patients = _patientRepository.PatientSearchByKeyword ( request.Keyword, request.PageIndex, request.PageSize, out totalCount );

            var patientDtos = Mapper.Map<IEnumerable<Patient>, IEnumerable<PatientDto>> ( patients );

            response.Patients = patientDtos;
            response.TotalCount = totalCount;
        }
    }
}
