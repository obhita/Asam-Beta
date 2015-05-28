using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Signs of Withdrawal
    /// </summary>
    public class SignsOfWithdrawal : Lookup
    {
        /// <summary>
        ///     NoRiskOfSevereWithdrawal = 0.
        /// </summary>
        public static readonly SignsOfWithdrawal NoRiskOfSevereWithdrawal = new SignsOfWithdrawal
            {
                Code = "NoRiskOfSevereWithdrawal",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     MildRiskOfWithdrawalCanBeManagedAtCareLevel_I = 1.
        /// </summary>
        public static readonly SignsOfWithdrawal MildRiskOfWithdrawalCanBeManagedAtCareLevel_I = new SignsOfWithdrawal
            {
                Code = "MildRiskOfWithdrawalCanBeManagedAtCareLevel_I",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     RiskOfSevereWithdrawalOutsideProgram = 2.
        /// </summary>
        public static readonly SignsOfWithdrawal RiskOfSevereWithdrawalOutsideProgram = new SignsOfWithdrawal
            {
                Code = "RiskOfSevereWithdrawalOutsideProgram",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     CurrentOrImminentWithdrawalCanBeManagedAtLevel_III_2 = 3.
        /// </summary>
        public static readonly SignsOfWithdrawal CurrentOrImminentWithdrawalCanBeManagedAtLevel_III_2 = new SignsOfWithdrawal
            {
                Code = "CurrentOrImminentWithdrawalCanBeManagedAtLevel_III_2",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     CurrentOrImminentSevereWithdrawalCanBeManagedAtLevel_III_7 = 4.
        /// </summary>
        public static readonly SignsOfWithdrawal CurrentOrImminentSevereWithdrawalCanBeManagedAtLevel_III_7 = new SignsOfWithdrawal
            {
                Code = "CurrentOrImminentSevereWithdrawalCanBeManagedAtLevel_III_7",
                SortOrder = 3,
                Value = 4
            };

        /// <summary>
        ///     CurrentOrImminentSevereWithdrawal = 5.
        /// </summary>
        public static readonly SignsOfWithdrawal CurrentOrImminentSevereWithdrawal = new SignsOfWithdrawal
            {
                Code = "CurrentOrImminentSevereWithdrawal",
                SortOrder = 4,
                Value = 5
            };
    }
}