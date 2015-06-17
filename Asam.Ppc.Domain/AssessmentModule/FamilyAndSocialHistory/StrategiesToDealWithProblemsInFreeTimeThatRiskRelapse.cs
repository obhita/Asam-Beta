using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse : Lookup
    {
        /// <summary>
        ///     NoApparentProblemsOrHasActivitiesThatAreProtective = 0.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
            NoApparentProblemsOrHasActivitiesThatAreProtective = new StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
                {
                    Code = "NoApparentProblemsOrHasActivitiesThatAreProtective",
                    SortOrder = 1,
                    Value = 0
                };

        /// <summary>
        ///     HasSomePlansToDevelopHealthyLeisurePursuits = 1.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
            HasSomePlansToDevelopHealthyLeisurePursuits = new StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
                {
                    Code = "HasSomePlansToDevelopHealthyLeisurePursuits",
                    SortOrder = 2,
                    Value = 1
                };

        /// <summary>
        ///     MinimalIdeasForIncreasingAndorMaintainingSafety = 2.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
            MinimalIdeasForIncreasingAndorMaintainingSafety = new StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
                {
                    Code = "MinimalIdeasForIncreasingAndorMaintainingSafety",
                    SortOrder = 3,
                    Value = 2
                };

        /// <summary>
        ///     RejectsNeedToDevelopSafeRecreation = 3.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse RejectsNeedToDevelopSafeRecreation
            = new StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
                {
                    Code = "RejectsNeedToDevelopSafeRecreation",
                    SortOrder = 4,
                    Value = 3
                };

        /// <summary>
        ///     PreferenceIsForHighRiskHobbies = 4.
        /// </summary>
        public static readonly StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse PreferenceIsForHighRiskHobbies = new StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse
            {
                Code = "PreferenceIsForHighRiskHobbies",
                SortOrder = 5,
                Value = 4
            };
    }
}