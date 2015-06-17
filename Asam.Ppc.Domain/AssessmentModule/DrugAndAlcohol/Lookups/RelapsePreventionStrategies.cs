using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Relapse Prevention Strategies
    /// </summary>
    public class RelapsePreventionStrategies : Lookup
    {
        /// <summary>
        ///     HasTrackRecordOfFrequentAndMultipleSuccessfulRecoveryApproaches = 0.
        /// </summary>
        public static readonly RelapsePreventionStrategies
            HasTrackRecordOfFrequentAndMultipleSuccessfulRecoveryApproaches = new RelapsePreventionStrategies
                {
                    Code = "HasTrackRecordOfFrequentAndMultipleSuccessfulRecoveryApproaches",
                    SortOrder = 1,
                    Value = 0
                };

        /// <summary>
        ///     ReadyForRegularMultipleEfforts = 1.
        /// </summary>
        public static readonly RelapsePreventionStrategies ReadyForRegularMultipleEfforts = new RelapsePreventionStrategies
            {
                Code = "ReadyForRegularMultipleEfforts",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     SomeIdeasAndOccasionalEffort = 2.
        /// </summary>
        public static readonly RelapsePreventionStrategies SomeIdeasAndOccasionalEffort = new RelapsePreventionStrategies
            {
                Code = "SomeIdeasAndOccasionalEffort",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     PassiveOrVague = 3.
        /// </summary>
        public static readonly RelapsePreventionStrategies PassiveOrVague = new RelapsePreventionStrategies
            {
                Code = "PassiveOrVague",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     HighlyAmbivalentOrRejectsNeed = 4.
        /// </summary>
        public static readonly RelapsePreventionStrategies HighlyAmbivalentOrRejectsNeed = new RelapsePreventionStrategies
            {
                Code = "HighlyAmbivalentOrRejectsNeed",
                SortOrder = 5,
                Value = 4
            };
    }
}