namespace Asam.Ppc.Infrastructure.Domain.AutoMappingOverrides
{
    #region Using Statements

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Ppc.Domain.Scoring.ScoringModule.Diagnosis;

    #endregion

    public class DiagnosisResultsOverride : IAutoMappingOverride<DiagnosisResults>
    {
        /// <summary>
        ///     Overrides the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping.</param>
        public void Override(AutoMapping<DiagnosisResults> mapping)
        {
            mapping.References(d => d.CommonScores).Unique().Cascade.All();
            mapping.References(d => d.DiagnosticStatisticalManualOfMentalDisorders_IV_Scores).Unique().Cascade.All();
        }
    }
}