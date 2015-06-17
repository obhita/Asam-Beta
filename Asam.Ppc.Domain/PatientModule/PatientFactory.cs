using System;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Primitives;

namespace Asam.Ppc.Domain.PatientModule
{
    using OrganizationModule;

    public class PatientFactory : IPatientFactory
    {
        private readonly IPatientRepository _patientRepository;

        public PatientFactory (IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient Create(Organization organization, PersonName personName, DateTime? dateOfBirth, Gender gender)
        {
            var patient = new Patient(organization, personName, dateOfBirth, gender);
            _patientRepository.MakePersistent ( patient );
            return patient;
        }
    }
}