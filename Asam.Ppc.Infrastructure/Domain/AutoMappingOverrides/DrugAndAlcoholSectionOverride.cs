namespace Asam.Ppc.Infrastructure.Domain.AutoMappingOverrides
{
    #region Using Statements

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Ppc.Domain.AssessmentModule.DrugAndAlcohol;

    #endregion

    #region Using Statements

    #endregion

    /// <summary>
    ///     Automapping override for DrugAndAlcoholSection.
    /// </summary>
    public class DrugAndAlcoholSectionOverride : IAutoMappingOverride<DrugAndAlcoholSection>
    {
        /// <summary>
        ///     Overrides the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping.</param>
        public void Override(AutoMapping<DrugAndAlcoholSection> mapping)
        {
            mapping.References(d => d.AddictionTreatmentHistory).Unique().Cascade.All();
            mapping.References(d => d.AdditionalAddictionAndTreatmentItems).Unique().Cascade.All();
            mapping.References(d => d.AlcoholAndDrugInterviewerRating).Unique().Cascade.All();
            mapping.References(d => d.AlcoholUse).Unique().Cascade.All();
            mapping.References(d => d.BarbiturateUse).Unique().Cascade.All();
            mapping.References(d => d.CannabisUse).Unique().Cascade.All();
            mapping.References(d => d.CinaScale).Unique().Cascade.All();
            mapping.References(d => d.CiwaScale).Unique().Cascade.All();
            mapping.References(d => d.CocaineUse).Unique().Cascade.All();
            mapping.References(d => d.DrugConsequences).Unique().Cascade.All();
            mapping.References(d => d.HallucinogenUse).Unique().Cascade.All();
            mapping.References(d => d.HeroinUse).Unique().Cascade.All();
            mapping.References(d => d.InterviewerEvaluation).Unique().Cascade.All();
            mapping.References(d => d.MethadoneUse).Unique().Cascade.All();
            mapping.References(d => d.MultipleSubstanceUsePerDay).Unique().Cascade.All();
            mapping.References(d => d.NicotineUse).Unique().Cascade.All();
            mapping.References(d => d.OpiatesInControlledEnvironment).Unique().Cascade.All();
            mapping.References(d => d.OpioidMaintenanceTherapy).Unique().Cascade.All();
            mapping.References(d => d.OtherOpiateUse).Unique().Cascade.All();
            mapping.References(d => d.OtherSedativeUse).Unique().Cascade.All();
            mapping.References(d => d.OtherSubstanceUse).Unique().Cascade.All();
            mapping.References(d => d.SolventAndInhalantUse).Unique().Cascade.All();
            mapping.References(d => d.StimulantUse).Unique().Cascade.All();
            mapping.References(d => d.UsedSubstances).Unique().Cascade.All();
        }
    }
}