namespace Asam.Ppc.Domain.PatientModule
{
    using System;
    using CommonModule.Lookups;
    using Primitives;
    using OrganizationModule;

    public interface IPatientFactory
    {
        Patient Create(Organization organization, PersonName personName, DateTime? dateOfBirth, Gender gender);
    }
}