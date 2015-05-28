using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Tactile Disturbances Observation
    /// </summary>
    public class TactileDisturbancesObservation : Lookup
    {
        /// <summary>
        ///     None = 0.
        /// </summary>
        public static readonly TactileDisturbancesObservation None = new TactileDisturbancesObservation
            {
                Code = "None",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     VeryMildItchingPinsAndNeedlesBurningOrNumbness = 1.
        /// </summary>
        public static readonly TactileDisturbancesObservation VeryMildItchingPinsAndNeedlesBurningOrNumbness = new TactileDisturbancesObservation
            {
                Code = "VeryMildItchingPinsAndNeedlesBurningOrNumbness",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     MildItchingPinsAndNeedlesBurningOrNumbness = 2.
        /// </summary>
        public static readonly TactileDisturbancesObservation MildItchingPinsAndNeedlesBurningOrNumbness = new TactileDisturbancesObservation
            {
                Code = "MildItchingPinsAndNeedlesBurningOrNumbness",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     ModerateItchingPinsAndNeedlesBurningOrNumbness = 3.
        /// </summary>
        public static readonly TactileDisturbancesObservation ModerateItchingPinsAndNeedlesBurningOrNumbness = new TactileDisturbancesObservation
            {
                Code = "ModerateItchingPinsAndNeedlesBurningOrNumbness",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ModeratelySevereHallucinations = 4.
        /// </summary>
        public static readonly TactileDisturbancesObservation ModeratelySevereHallucinations = new TactileDisturbancesObservation
            {
                Code = "ModeratelySevereHallucinations",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     SevereHallucinations = 5.
        /// </summary>
        public static readonly TactileDisturbancesObservation SevereHallucinations = new TactileDisturbancesObservation
            {
                Code = "SevereHallucinations",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     ExtremelySevereHallucinations = 6.
        /// </summary>
        public static readonly TactileDisturbancesObservation ExtremelySevereHallucinations = new TactileDisturbancesObservation
            {
                Code = "ExtremelySevereHallucinations",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     ContinuousHallucinations = 7.
        /// </summary>
        public static readonly TactileDisturbancesObservation ContinuousHallucinations = new TactileDisturbancesObservation
            {
                Code = "ContinuousHallucinations",
                SortOrder = 8,
                Value = 7
            };
    }
}