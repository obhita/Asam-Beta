using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Yawning Observation
    /// </summary>
    public class YawningObservation : Lookup
    {
        /// <summary>
        ///     NoYawning = 0.
        /// </summary>
        public static readonly YawningObservation NoYawning = new YawningObservation
            {
                Code = "NoYawning",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     FrequentYawning = 1.
        /// </summary>
        public static readonly YawningObservation FrequentYawning = new YawningObservation
            {
                Code = "FrequentYawning",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ConstantUncontrolledYawning = 2.
        /// </summary>
        public static readonly YawningObservation ConstantUncontrolledYawning = new YawningObservation
            {
                Code = "ConstantUncontrolledYawning",
                SortOrder = 3,
                Value = 2
            };
    }
}