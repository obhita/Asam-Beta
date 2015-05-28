using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Sweating Observation
    /// </summary>
    public class SweatingObservation : Lookup
    {
        /// <summary>
        ///     NoSweatVisible = 0.
        /// </summary>
        public static readonly SweatingObservation NoSweatVisible = new SweatingObservation
            {
                Code = "NoSweatVisible",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     BarelyPerceptibleSweatingPalmsMoistNoOtherSigns = 1.
        /// </summary>
        public static readonly SweatingObservation BarelyPerceptibleSweatingPalmsMoistNoOtherSigns = new SweatingObservation
            {
                Code = "BarelyPerceptibleSweatingPalmsMoistNoOtherSigns",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     BeadsOfSweatObviousOnForehead = 2.
        /// </summary>
        public static readonly SweatingObservation BeadsOfSweatObviousOnForehead = new SweatingObservation
            {
                Code = "BeadsOfSweatObviousOnForehead",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     DrenchingSweatsOverFaceAndChest = 3.
        /// </summary>
        public static readonly SweatingObservation DrenchingSweatsOverFaceAndChest = new SweatingObservation
            {
                Code = "DrenchingSweatsOverFaceAndChest",
                SortOrder = 4,
                Value = 3
            };
    }
}