using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Lacrimination Observation
    /// </summary>
    public class LacriminationObservation : Lookup
    {
        /// <summary>
        ///     NoLacrimation = 0.
        /// </summary>
        public static readonly LacriminationObservation NoLacrimation = new LacriminationObservation
            {
                Code = "NoLacrimation",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     TearsAtCornersOfEyes = 1.
        /// </summary>
        public static readonly LacriminationObservation TearsAtCornersOfEyes = new LacriminationObservation
            {
                Code = "TearsAtCornersOfEyes",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ProfuseTearsFromEyesOverFace = 2.
        /// </summary>
        public static readonly LacriminationObservation ProfuseTearsFromEyesOverFace = new LacriminationObservation
            {
                Code = "ProfuseTearsFromEyesOverFace",
                SortOrder = 3,
                Value = 2
            };
    }
}