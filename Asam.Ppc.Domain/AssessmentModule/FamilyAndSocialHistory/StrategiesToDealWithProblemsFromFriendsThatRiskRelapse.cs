using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class StrategiesToDealWithProblemsFromFriendsThatRiskRelapse : Lookup
    {
        /// <summary>
        ///     HasTrackRecordOfCopingEffectivelyWithProblems = 0.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
            HasTrackRecordOfCopingEffectivelyWithProblems = new StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
                {
                    Code = "HasTrackRecordOfCopingEffectivelyWithProblems",
                    SortOrder = 1,
                    Value = 0
                };

        /// <summary>
        ///     HealthySocialNetworkAndSkills = 1.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsFromFriendsThatRiskRelapse HealthySocialNetworkAndSkills = new StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
            {
                Code = "HealthySocialNetworkAndSkills",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     SomePlansToUseRecoverySupports = 2.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsFromFriendsThatRiskRelapse SomePlansToUseRecoverySupports = new StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
            {
                Code = "SomePlansToUseRecoverySupports",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     PassiveAboutDevelopingProtectiveRelationships = 3.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
            PassiveAboutDevelopingProtectiveRelationships = new StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
                {
                    Code = "PassiveAboutDevelopingProtectiveRelationships",
                    SortOrder = 4,
                    Value = 3
                };

        /// <summary>
        ///     ReclusiveOrDrawnToHighRiskSocialContacts = 4.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
            ReclusiveOrDrawnToHighRiskSocialContacts = new StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
                {
                    Code = "ReclusiveOrDrawnToHighRiskSocialContacts",
                    SortOrder = 5,
                    Value = 4
                };
    }
}