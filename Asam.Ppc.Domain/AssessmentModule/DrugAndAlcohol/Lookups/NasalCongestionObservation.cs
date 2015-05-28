using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Nasal Congestion Observation
    /// </summary>
    public class NasalCongestionObservation : Lookup
    {
        /// <summary>
        ///     NoNasalCongestionOrSniffling = 0.
        /// </summary>
        public static readonly NasalCongestionObservation NoNasalCongestionOrSniffling = new NasalCongestionObservation
            {
                Code = "NoNasalCongestionOrSniffling",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     FrequentSniffling = 1.
        /// </summary>
        public static readonly NasalCongestionObservation FrequentSniffling = new NasalCongestionObservation
            {
                Code = "FrequentSniffling",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ConstantSnifflingWithWateryDischarge = 2.
        /// </summary>
        public static readonly NasalCongestionObservation ConstantSnifflingWithWateryDischarge = new NasalCongestionObservation
            {
                Code = "ConstantSnifflingWithWateryDischarge",
                SortOrder = 3,
                Value = 2
            };
    }
}