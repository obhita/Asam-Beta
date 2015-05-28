namespace Asam.Ppc.Infrastructure.Domain.AutoMappingOverrides
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Ppc.Domain.AssessmentModule;

    #region Using Statements

    

    #endregion

    /// <summary>
    /// Automapping override for Assessment.
    /// </summary>
    public class AssessmentOverride : IAutoMappingOverride<Assessment>
    {
        /// <summary>
        /// Overrides the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping.</param>
        public void Override(AutoMapping<Assessment> mapping)
        {
            mapping.References(a => a.CompletionSection).Unique().Cascade.All();
            mapping.References(a => a.DrugAndAlcoholSection).Unique().Cascade.All();
            mapping.References(a => a.EmploymentAndSupportSection).Unique().Cascade.All();
            mapping.References(a => a.FamilyAndSocialHistorySection).Unique().Cascade.All();
            mapping.References(a => a.GeneralInformationSection).Unique().Cascade.All();
            mapping.References(a => a.LegalSection).Unique().Cascade.All();
            mapping.References(a => a.MedicalSection).Unique().Cascade.All();
            mapping.References(a => a.PsychologicalSection).Unique().Cascade.All();
        }
    }

    #region Using Statements



    #endregion
}