namespace Asam.Ppc.Infrastructure.Domain.AutoMappingOverrides
{
    #region Using Statements

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Ppc.Domain.AssessmentModule.Psychological;

    #endregion

    /// <summary>
    /// Automapping override for PsychologicalSection.
    /// </summary>
    public class PsychologicalSectionOverride : IAutoMappingOverride<PsychologicalSection>
    {
        /// <summary>
        ///     Overrides the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping.</param>
        public void Override(AutoMapping<PsychologicalSection> mapping)
        {
            mapping.References(p => p.DepressionEvaluation).Unique().Cascade.All();
            mapping.References(p => p.InterviewerRating).Unique().Cascade.All();
            mapping.References(p => p.PsychologicalHistory).Unique().Cascade.All();
        }
    }
}