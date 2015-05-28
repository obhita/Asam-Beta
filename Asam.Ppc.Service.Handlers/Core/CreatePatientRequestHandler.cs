using Asam.Ppc.Domain.CommonModule;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Common;
using Asam.Ppc.Service.Messages.Core;
using AutoMapper;

namespace Asam.Ppc.Service.Handlers.Core
{
    using Domain.OrganizationModule;
    using Infrastructure;

    public class CreatePatientRequestHandler : ServiceRequestHandler<CreatePatientRequest, SaveDtoResponse<PatientDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPatientFactory _patientFactory;

        public CreatePatientRequestHandler ( IOrganizationRepository organizationRepository, IPatientFactory patientFactory)
        {
            _organizationRepository = organizationRepository;
            _patientFactory = patientFactory;
        }

        protected override void Handle(CreatePatientRequest request, SaveDtoResponse<PatientDto> response)
        {
            var organization = _organizationRepository.GetByKey ( UserContext.OrganizationKey );
            var patientFactory = _patientFactory;
            var patient = patientFactory.Create ( organization, request.PatientDto.Name,
                                    request.PatientDto.DateOfBirth,
                                    Lookup.Find<Gender> ( request.PatientDto.Gender.Code ) );
            if (patient != null)
            {
                if (request.PatientDto.Religion != null)
                {
                    patient.ReviseReligion(Lookup.Find<Religion>(request.PatientDto.Religion.Code));
                }
                if (request.PatientDto.Ethnicity != null)
                {
                    patient.ReviseEthnicity(Lookup.Find<Ethnicity>(request.PatientDto.Ethnicity.Code));
                }

                var patientDto = Mapper.Map<Patient, PatientDto>(patient);

                response.DataTransferObject = patientDto;
            }
        }
    }
}
