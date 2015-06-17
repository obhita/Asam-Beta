using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class NeedForStaffSupportToMaintainRecovery : Lookup
    {
        /// <summary>
        ///     NotApplicable = 1.
        /// </summary>
        public static readonly NeedForStaffSupportToMaintainRecovery NotApplicable = new NeedForStaffSupportToMaintainRecovery
            {
                Code = "NotApplicable",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     NeedsContactApproximately1TimePerWeek = 2.
        /// </summary>
        public static readonly NeedForStaffSupportToMaintainRecovery NeedsContactApproximately1TimePerWeek = new NeedForStaffSupportToMaintainRecovery
            {
                Code = "NeedsContactApproximately1TimePerWeek",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     NeedsContactSeveralTimesPerWeek = 3.
        /// </summary>
        public static readonly NeedForStaffSupportToMaintainRecovery NeedsContactSeveralTimesPerWeek = new NeedForStaffSupportToMaintainRecovery
            {
                Code = "NeedsContactSeveralTimesPerWeek",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     NeedsContactDaily = 4.
        /// </summary>
        public static readonly NeedForStaffSupportToMaintainRecovery NeedsContactDaily = new NeedForStaffSupportToMaintainRecovery
            {
                Code = "NeedsContactDaily",
                SortOrder = 4,
                Value = 4
            };
    }
}