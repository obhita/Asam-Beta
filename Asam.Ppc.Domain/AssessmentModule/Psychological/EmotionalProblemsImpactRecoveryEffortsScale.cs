using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class EmotionalProblemsImpactRecoveryEffortsScale : Lookup
    {
        /// <summary>
        ///     NoProblems = 0.
        /// </summary>
        public static readonly EmotionalProblemsImpactRecoveryEffortsScale NoProblems = new EmotionalProblemsImpactRecoveryEffortsScale
            {
                Code = "NoProblems",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     ProblemsWontInterfere = 1.
        /// </summary>
        public static readonly EmotionalProblemsImpactRecoveryEffortsScale ProblemsWontInterfere = new EmotionalProblemsImpactRecoveryEffortsScale
            {
                Code = "ProblemsWontInterfere",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     SomewhatDistractingFromRecovery = 2.
        /// </summary>
        public static readonly EmotionalProblemsImpactRecoveryEffortsScale SomewhatDistractingFromRecovery = new EmotionalProblemsImpactRecoveryEffortsScale
            {
                Code = "SomewhatDistractingFromRecovery",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     WillHinderTreatmentRecoveryParticipation = 3.
        /// </summary>
        public static readonly EmotionalProblemsImpactRecoveryEffortsScale WillHinderTreatmentRecoveryParticipation = new EmotionalProblemsImpactRecoveryEffortsScale
            {
                Code = "WillHinderTreatmentRecoveryParticipation",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     LikelyToThreatenRecovery = 4.
        /// </summary>
        public static readonly EmotionalProblemsImpactRecoveryEffortsScale LikelyToThreatenRecovery = new EmotionalProblemsImpactRecoveryEffortsScale
            {
                Code = "LikelyToThreatenRecovery",
                SortOrder = 5,
                Value = 4
            };
    }
}