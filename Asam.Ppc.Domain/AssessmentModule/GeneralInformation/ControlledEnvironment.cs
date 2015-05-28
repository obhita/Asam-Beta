using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.GeneralInformation
{
    public class ControlledEnvironment : Lookup
    {
        /// <summary>
        ///     None = 0.
        /// </summary>
        public static readonly ControlledEnvironment None = new ControlledEnvironment
            {
                Code = "None",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Jail = 1.
        /// </summary>
        public static readonly ControlledEnvironment Jail = new ControlledEnvironment
            {
                Code = "Jail",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     AlcoholOrDrugTreatment = 2.
        /// </summary>
        public static readonly ControlledEnvironment AlcoholOrDrugTreatment = new ControlledEnvironment
            {
                Code = "AlcoholOrDrugTreatment",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     MedicalTreatment = 3.
        /// </summary>
        public static readonly ControlledEnvironment MedicalTreatment = new ControlledEnvironment
            {
                Code = "MedicalTreatment",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     PsychiatricTreatment = 4.
        /// </summary>
        public static readonly ControlledEnvironment PsychiatricTreatment = new ControlledEnvironment
            {
                Code = "PsychiatricTreatment",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     OtherControlledEnvironment = 5.
        /// </summary>
        public static readonly ControlledEnvironment OtherControlledEnvironment = new ControlledEnvironment
            {
                Code = "OtherControlledEnvironment",
                SortOrder = 6,
                Value = 5
            };
    }
}