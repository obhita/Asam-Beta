using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class FriendsAffectOnRecovery : Lookup
    {
        /// <summary>
        ///     AllAreInRecoveryAndIncludeSponsor = 0.
        /// </summary>
        public static readonly FriendsAffectOnRecovery AllAreInRecoveryAndIncludeSponsor = new FriendsAffectOnRecovery
            {
                Code = "AllAreInRecoveryAndIncludeSponsor",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     WillBeSupportiveAndProtective = 1.
        /// </summary>
        public static readonly FriendsAffectOnRecovery WillBeSupportiveAndProtective = new FriendsAffectOnRecovery
            {
                Code = "WillBeSupportiveAndProtective",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     WillPermitRecovery = 2.
        /// </summary>
        public static readonly FriendsAffectOnRecovery WillPermitRecovery = new FriendsAffectOnRecovery
            {
                Code = "WillPermitRecovery",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     WillDiscourageOrHinderTreatmentrecovery = 3.
        /// </summary>
        public static readonly FriendsAffectOnRecovery WillDiscourageOrHinderTreatmentrecovery = new FriendsAffectOnRecovery
            {
                Code = "WillDiscourageOrHinderTreatmentrecovery",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     WillOftenExposePatientToSubstanceUse = 4.
        /// </summary>
        public static readonly FriendsAffectOnRecovery WillOftenExposePatientToSubstanceUse = new FriendsAffectOnRecovery
            {
                Code = "WillOftenExposePatientToSubstanceUse",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     HasNoFriends = -1.
        /// </summary>
        public static readonly FriendsAffectOnRecovery HasNoFriends = new FriendsAffectOnRecovery
            {
                Code = "HasNoFriends",
                SortOrder = 6,
                Value = -1
            };
    }
}