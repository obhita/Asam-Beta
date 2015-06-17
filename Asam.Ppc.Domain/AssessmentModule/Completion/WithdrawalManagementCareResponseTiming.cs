using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Completion
{
    /// <summary>
    /// Detoxification Care Response Timing
    /// </summary>
    public class WithdrawalManagementCareResponseTiming : Lookup
    {
        /// <summary>
        ///     NoneOrWithdrawalSymptomsDoNotRequireMonitoring = 0.
        /// </summary>
        public static readonly WithdrawalManagementCareResponseTiming NoneOrWithdrawalSymptomsDoNotRequireMonitoring = new WithdrawalManagementCareResponseTiming
            {
                Code = "NoneOrWithdrawalSymptomsDoNotRequireMonitoring",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Within2Hours = 1.
        /// </summary>
        public static readonly WithdrawalManagementCareResponseTiming Within2Hours = new WithdrawalManagementCareResponseTiming
            {
                Code = "Within2Hours",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Within4To8Hours = 2.
        /// </summary>
        public static readonly WithdrawalManagementCareResponseTiming Within4To8Hours = new WithdrawalManagementCareResponseTiming
            {
                Code = "Within4To8Hours",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Within8To24Hours = 3.
        /// </summary>
        public static readonly WithdrawalManagementCareResponseTiming Within8To24Hours = new WithdrawalManagementCareResponseTiming
            {
                Code = "Within8To24Hours",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     MoreThan24Hours = 4.
        /// </summary>
        public static readonly WithdrawalManagementCareResponseTiming MoreThan24Hours = new WithdrawalManagementCareResponseTiming
            {
                Code = "MoreThan24Hours",
                SortOrder = 5,
                Value = 4
            };
    }
}