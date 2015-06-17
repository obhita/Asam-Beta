using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class PhysicalHealthsEffectOnSubstanceProblems : Lookup
    {
        /// <summary>
        ///     NoneOrSlightProblemsThatWontInterfereWithRecovery = 0.
        /// </summary>
        public static readonly PhysicalHealthsEffectOnSubstanceProblems
            NoneOrSlightProblemsThatWontInterfereWithRecovery = new PhysicalHealthsEffectOnSubstanceProblems
                {
                    Code = "NoneOrSlightProblemsThatWontInterfereWithRecovery",
                    SortOrder = 1,
                    Value = 0
                };

        /// <summary>
        ///     SlightProblemsWontInterfereWithRecovery = 1.
        /// </summary>
        public static readonly PhysicalHealthsEffectOnSubstanceProblems SlightProblemsWontInterfereWithRecovery = new PhysicalHealthsEffectOnSubstanceProblems
            {
                Code = "SlightProblemsWontInterfereWithRecovery",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     SomewhatDistractingFromRecovery = 2.
        /// </summary>
        public static readonly PhysicalHealthsEffectOnSubstanceProblems SomewhatDistractingFromRecovery = new PhysicalHealthsEffectOnSubstanceProblems
            {
                Code = "SomewhatDistractingFromRecovery",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     SomeLikelihoodToHinderRecovery = 3.
        /// </summary>
        public static readonly PhysicalHealthsEffectOnSubstanceProblems SomeLikelihoodToHinderRecovery = new PhysicalHealthsEffectOnSubstanceProblems
            {
                Code = "SomeLikelihoodToHinderRecovery",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     WillThreatenRecovery = 4.
        /// </summary>
        public static readonly PhysicalHealthsEffectOnSubstanceProblems WillThreatenRecovery = new PhysicalHealthsEffectOnSubstanceProblems
            {
                Code = "WillThreatenRecovery",
                SortOrder = 5,
                Value = 4
            };
    }
}