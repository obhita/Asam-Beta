using Asam.Ppc.Domain.CommonModule;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Common;
using Asam.Ppc.Service.Messages.Core;
using AutoMapper;

namespace Asam.Ppc.Service.Handlers.Core
{
    public class SavePatientDtoRequestHandler : ServiceRequestHandler<SaveDtoRequest<PatientDto>, SaveDtoResponse<PatientDto>>
    {
        private readonly IPatientRepository _patientRepository;

        public SavePatientDtoRequestHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        protected override void Handle(SaveDtoRequest<PatientDto> request, SaveDtoResponse<PatientDto> response)
        {
            var patient = _patientRepository.GetByKey ( request.DataTransferObject.Key );
            if (patient != null)
            {
                //patient.ReviseName(request.DataTransferObject.Name);
                //patient.ReviseDateOfBirth(request.DataTransferObject.DateOfBirth);
                //patient.ReviseGender(Lookup.Find<Gender>(request.DataTransferObject.Gender.Code));
                patient.ReviseEthnicity(Lookup.Find<Ethnicity>(request.DataTransferObject.Ethnicity.Code));
                patient.ReviseReligion(Lookup.Find<Religion>(request.DataTransferObject.Religion.Code));

                response.DataTransferObject = Mapper.Map<Patient, PatientDto>(patient);
            }
        }
    }
}
