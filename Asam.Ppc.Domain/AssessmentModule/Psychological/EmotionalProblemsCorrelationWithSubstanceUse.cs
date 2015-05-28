using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class EmotionalProblemsCorrelationWithSubstanceUse : Lookup
    {
        /// <summary>
        ///     NoPastOrCurrentSymptoms = 0.
        /// </summary>
        public static readonly EmotionalProblemsCorrelationWithSubstanceUse NoPastOrCurrentSymptoms = new EmotionalProblemsCorrelationWithSubstanceUse
            {
                Code = "NoPastOrCurrentSymptoms",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     SymptomsOnlyRelatedToSubstanceUse = 1.
        /// </summary>
        public static readonly EmotionalProblemsCorrelationWithSubstanceUse SymptomsOnlyRelatedToSubstanceUse = new EmotionalProblemsCorrelationWithSubstanceUse
            {
                Code = "SymptomsOnlyRelatedToSubstanceUse",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     RelationToSubstanceUseIsUnclear = 2.
        /// </summary>
        public static readonly EmotionalProblemsCorrelationWithSubstanceUse RelationToSubstanceUseIsUnclear = new EmotionalProblemsCorrelationWithSubstanceUse
            {
                Code = "RelationToSubstanceUseIsUnclear",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     ProblemsIndependentOfSubstanceUse = 3.
        /// </summary>
        public static readonly EmotionalProblemsCorrelationWithSubstanceUse ProblemsIndependentOfSubstanceUse = new EmotionalProblemsCorrelationWithSubstanceUse
            {
                Code = "ProblemsIndependentOfSubstanceUse",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ProblemsIndependentOfSubstanceUseAndAddictionMayExacerbate = 4.
        /// </summary>
        public static readonly EmotionalProblemsCorrelationWithSubstanceUse
            ProblemsIndependentOfSubstanceUseAndAddictionMayExacerbate = new EmotionalProblemsCorrelationWithSubstanceUse
                {
                    Code = "ProblemsIndependentOfSubstanceUseAndAddictionMayExacerbate",
                    SortOrder = 5,
                    Value = 4
                };
    }
}