using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Nervousness Observation
    /// </summary>
    public class NervousnessObservation : Lookup
    {
        /// <summary>
        ///     NoAnxiety = 0.
        /// </summary>
        public static readonly NervousnessObservation NoAnxiety = new NervousnessObservation
            {
                Code = "NoAnxiety",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     MildAnxiety = 1.
        /// </summary>
        public static readonly NervousnessObservation MildAnxiety = new NervousnessObservation
            {
                Code = "MildAnxiety",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ModerateAnxiety = 4.
        /// </summary>
        public static readonly NervousnessObservation ModerateAnxiety = new NervousnessObservation
            {
                Code = "ModerateAnxiety",
                SortOrder = 3,
                Value = 4
            };

        /// <summary>
        ///     SevereAnxiety = 7.
        /// </summary>
        public static readonly NervousnessObservation SevereAnxiety = new NervousnessObservation
            {
                Code = "SevereAnxiety",
                SortOrder = 4,
                Value = 7
            };
    }
}