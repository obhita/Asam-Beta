using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class TreatmentNeedLevel : Lookup
    {
        /// <summary>
        ///     None = 0.
        /// </summary>
        public static readonly TreatmentNeedLevel None = new TreatmentNeedLevel
            {
                Code = "None",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     OneVisitPerMonth = 1.
        /// </summary>
        public static readonly TreatmentNeedLevel OneVisitPerMonth = new TreatmentNeedLevel
            {
                Code = "OneVisitPerMonth",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     TwoToFourVisitsPerMonth = 2.
        /// </summary>
        public static readonly TreatmentNeedLevel TwoToFourVisitsPerMonth = new TreatmentNeedLevel
            {
                Code = "TwoToFourVisitsPerMonth",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     MoreThanOneVisitPerWeek = 3.
        /// </summary>
        public static readonly TreatmentNeedLevel MoreThanOneVisitPerWeek = new TreatmentNeedLevel
            {
                Code = "MoreThanOneVisitPerWeek",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     Hospitalization = 4.
        /// </summary>
        public static readonly TreatmentNeedLevel Hospitalization = new TreatmentNeedLevel
            {
                Code = "Hospitalization",
                SortOrder = 5,
                Value = 4
            };
    }
}