using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class LivingArrangementAffectOnRecovery : Lookup
    {
        /// <summary>
        ///     DailyRoutineWillGratifyShieldFromSubstances = 0.
        /// </summary>
        public static readonly LivingArrangementAffectOnRecovery DailyRoutineWillGratifyShieldFromSubstances = new LivingArrangementAffectOnRecovery
            {
                Code = "DailyRoutineWillGratifyShieldFromSubstances",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     FreeTimeActivitiesWillSupportDistractFromSubstanceUse = 1.
        /// </summary>
        public static readonly LivingArrangementAffectOnRecovery FreeTimeActivitiesWillSupportDistractFromSubstanceUse = new LivingArrangementAffectOnRecovery
            {
                Code = "FreeTimeActivitiesWillSupportDistractFromSubstanceUse",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     WillPermitRecoveryIfSufficientlyMotivated = 2.
        /// </summary>
        public static readonly LivingArrangementAffectOnRecovery WillPermitRecoveryIfSufficientlyMotivated = new LivingArrangementAffectOnRecovery
            {
                Code = "WillPermitRecoveryIfSufficientlyMotivated",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     WillDiscourageOrHinderTreatment = 3.
        /// </summary>
        public static readonly LivingArrangementAffectOnRecovery WillDiscourageOrHinderTreatment = new LivingArrangementAffectOnRecovery
            {
                Code = "WillDiscourageOrHinderTreatment",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     WillOftenExposeToSubstanceUse = 4.
        /// </summary>
        public static readonly LivingArrangementAffectOnRecovery WillOftenExposeToSubstanceUse = new LivingArrangementAffectOnRecovery
            {
                Code = "WillOftenExposeToSubstanceUse",
                SortOrder = 5,
                Value = 4
            };
    }
}