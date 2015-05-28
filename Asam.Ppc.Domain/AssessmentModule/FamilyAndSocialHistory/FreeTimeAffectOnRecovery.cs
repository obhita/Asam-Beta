using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class FreeTimeAffectOnRecovery : Lookup
    {
        /// <summary>
        ///     DailyRoutineWillGratifyAndShieldFromSubstances = 0.
        /// </summary>
        public static readonly FreeTimeAffectOnRecovery DailyRoutineWillGratifyAndShieldFromSubstances = new FreeTimeAffectOnRecovery
            {
                Code = "DailyRoutineWillGratifyAndShieldFromSubstances",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     FreeTimeActivitiesWillSupportAndDistractFromSubstanceUse = 1.
        /// </summary>
        public static readonly FreeTimeAffectOnRecovery FreeTimeActivitiesWillSupportAndDistractFromSubstanceUse = new FreeTimeAffectOnRecovery
            {
                Code = "FreeTimeActivitiesWillSupportAndDistractFromSubstanceUse",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     WillPermitRecoveryIfSufficientlyMotivated = 2.
        /// </summary>
        public static readonly FreeTimeAffectOnRecovery WillPermitRecoveryIfSufficientlyMotivated = new FreeTimeAffectOnRecovery
            {
                Code = "WillPermitRecoveryIfSufficientlyMotivated",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     WillDiscourageOrHinderRecovery = 3.
        /// </summary>
        public static readonly FreeTimeAffectOnRecovery WillDiscourageOrHinderRecovery = new FreeTimeAffectOnRecovery
            {
                Code = "WillDiscourageOrHinderRecovery",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     WillOftenExposeToSubstanceUse = 4.
        /// </summary>
        public static readonly FreeTimeAffectOnRecovery WillOftenExposeToSubstanceUse = new FreeTimeAffectOnRecovery
            {
                Code = "WillOftenExposeToSubstanceUse",
                SortOrder = 5,
                Value = 4
            };
    }
}