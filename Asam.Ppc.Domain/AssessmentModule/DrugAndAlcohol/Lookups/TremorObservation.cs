using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Tremor Observation
    /// </summary>
    public class TremorObservation : Lookup
    {
        /// <summary>
        ///     NoTremor = 0.
        /// </summary>
        public static readonly TremorObservation NoTremor = new TremorObservation
            {
                Code = "NoTremor",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     NotVisibleButCanBeFeltFingertipToFingertip = 1.
        /// </summary>
        public static readonly TremorObservation NotVisibleButCanBeFeltFingertipToFingertip = new TremorObservation
            {
                Code = "NotVisibleButCanBeFeltFingertipToFingertip",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ModerateTremorWithPatientsArmExtended = 4.
        /// </summary>
        public static readonly TremorObservation ModerateTremorWithPatientsArmExtended = new TremorObservation
            {
                Code = "ModerateTremorWithPatientsArmExtended",
                SortOrder = 3,
                Value = 4
            };

        /// <summary>
        ///     SevereEvenWithArmsNotExtendedAndRelaxedAtSides = 7.
        /// </summary>
        public static readonly TremorObservation SevereEvenWithArmsNotExtendedAndRelaxedAtSides = new TremorObservation
            {
                Code = "SevereEvenWithArmsNotExtendedAndRelaxedAtSides",
                SortOrder = 4,
                Value = 7
            };
    }
}