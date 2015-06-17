using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Goose Flesh Observation
    /// </summary>
    public class GooseFleshObservation : Lookup
    {
        /// <summary>
        ///     NoGooseFleshIsVisible = 0.
        /// </summary>
        public static readonly GooseFleshObservation NoGooseFleshIsVisible = new GooseFleshObservation
            {
                Code = "NoGooseFleshIsVisible",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     OccasionalGooseFleshButNotElicitedByTouchAndNotProminent = 2.
        /// </summary>
        public static readonly GooseFleshObservation OccasionalGooseFleshButNotElicitedByTouchAndNotProminent = new GooseFleshObservation
            {
                Code = "OccasionalGooseFleshButNotElicitedByTouchAndNotProminent",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     ProminentGooseFleshInWavesAndElicitedByTouch = 4.
        /// </summary>
        public static readonly GooseFleshObservation ProminentGooseFleshInWavesAndElicitedByTouch = new GooseFleshObservation
            {
                Code = "ProminentGooseFleshInWavesAndElicitedByTouch",
                SortOrder = 3,
                Value = 4
            };

        /// <summary>
        ///     ConstantGooseFleshOverChestAndArms = 6.
        /// </summary>
        public static readonly GooseFleshObservation ConstantGooseFleshOverChestAndArms = new GooseFleshObservation
            {
                Code = "ConstantGooseFleshOverChestAndArms",
                SortOrder = 4,
                Value = 6
            };
    }
}