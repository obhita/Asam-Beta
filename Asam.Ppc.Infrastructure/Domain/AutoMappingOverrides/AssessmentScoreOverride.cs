namespace Asam.Ppc.Infrastructure.Domain.AutoMappingOverrides
{
    #region Using Statements

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Ppc.Domain.Scoring.ScoringModule;

    #endregion

    public class AssessmentScoreOverride : IAutoMappingOverride<AssessmentScore>
    {
        /// <summary>
        ///     Overrides the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping.</param>
        public void Override(AutoMapping<AssessmentScore> mapping)
        {
            mapping.References(a => a.DiagnosisResults).Unique().Cascade.All();
            mapping.References(a => a.Dimension1WithdrawalScores).Unique().Cascade.All();
            mapping.References(a => a.Dimension2BiomedicalScores).Unique().Cascade.All();
            mapping.References(a => a.Dimension3EmotionalBehavioralScores).Unique().Cascade.All();
            mapping.References(a => a.Dimension4ReadinessToChangeScores).Unique().Cascade.All();
            mapping.References(a => a.Dimension5RelapsePotentialScores).Unique().Cascade.All();
            mapping.References(a => a.Dimension6LivingEnvironmentScores).Unique().Cascade.All();
            mapping.References(a => a.DimensionalAdmissionCriteriaResults).Unique().Cascade.All();
        }
    }
}