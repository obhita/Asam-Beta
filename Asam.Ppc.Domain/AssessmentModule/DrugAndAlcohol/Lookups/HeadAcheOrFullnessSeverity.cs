using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Head Ache or Fullness Severity
    /// </summary>
    public class HeadAcheOrFullnessSeverity : Lookup
    {
        /// <summary>
        ///     NotPresent = 0.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity NotPresent = new HeadAcheOrFullnessSeverity
            {
                Code = "NotPresent",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     VeryMild = 1.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity VeryMild = new HeadAcheOrFullnessSeverity
            {
                Code = "VeryMild",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Mild = 2.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity Mild = new HeadAcheOrFullnessSeverity
            {
                Code = "Mild",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Moderate = 3.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity Moderate = new HeadAcheOrFullnessSeverity
            {
                Code = "Moderate",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ModeratelySevere = 4.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity ModeratelySevere = new HeadAcheOrFullnessSeverity
            {
                Code = "ModeratelySevere",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     Severe = 5.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity Severe = new HeadAcheOrFullnessSeverity
            {
                Code = "Severe",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     VerySevere = 6.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity VerySevere = new HeadAcheOrFullnessSeverity
            {
                Code = "VerySevere",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     ExtremelySevere = 7.
        /// </summary>
        public static readonly HeadAcheOrFullnessSeverity ExtremelySevere = new HeadAcheOrFullnessSeverity
            {
                Code = "ExtremelySevere",
                SortOrder = 8,
                Value = 7
            };
    }
}