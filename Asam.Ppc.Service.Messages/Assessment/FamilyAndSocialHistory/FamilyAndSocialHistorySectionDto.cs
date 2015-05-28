namespace Asam.Ppc.Service.Messages.Assessment.FamilyAndSocialHistory
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class FamilyAndSocialHistorySectionDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 42 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "NeedsAndWillingnessToHelpTreatment" )]
        public LookupDto ClosestContactsNeedsAndWillingnessToHelpTreatment { get; set; }

        [Display ( Order = 38 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "ContactPerson" )]
        public LookupDto ClosestPersonalContactInPast4Months { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "StrategiesToDealWithProblemsFromFriendsThatRiskRelapse" )]
        public LookupDto DealsWithProblemsFromFriendsThatRiskRelapse { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse" )]
        public LookupDto DealsWithProblemsInFreeTimeThatRiskRelapse { get; set; }

        [Display ( Order = 35 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto EmotionalAbuseInPast30Days { get; set; }

        [Display ( Order = 41 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto FreeTimeAffectOnRecovery { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto FriendsAffectOnRecovery { get; set; }

        [Display ( Order = 21 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithChildren { get; set; }

        [Display ( Order = 23 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithCloseFriends { get; set; }

        [Display ( Order = 25 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_LifetimeHeader", "SixColumns" )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithCoworkers { get; set; }

        [Display ( Order = 18 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithFather { get; set; }

        [Display ( Order = 17 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_SeriousProblemsHeader", 0 )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_LifetimeHeader", 1, "SixColumns" )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithMother { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithNeighbors { get; set; }

        [Display ( Order = 22 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithOtherFamily { get; set; }

        [Display ( Order = 20 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithSexPartner { get; set; }

        [Display ( Order = 19 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInLifetimeWithSibling { get; set; }

        [Display ( Order = 30 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithChildren { get; set; }

        [Display ( Order = 32 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithCloseFriends { get; set; }

        [Display ( Order = 34 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_PastMonthHeader", 0, "SixColumns" )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_SeriousProblemsHeader", 1 )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithCoworkers { get; set; }

        [Display ( Order = 27 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithFather { get; set; }

        [Display ( Order = 26 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_PastMonthHeader", "SixColumns" )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithMother { get; set; }

        [Display ( Order = 33 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithNeighbors { get; set; }

        [Display ( Order = 31 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithOtherFamily { get; set; }

        [Display ( Order = 29 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithSexPartner { get; set; }

        [Display ( Order = 28 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto HadProblemsInPastMonthWithSibling { get; set; }

        [Display ( Order = 39 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto HasRecentlyNeglectedOrAbusedFamilyMembers { get; set; }

        [Display ( Order = 43 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto HowLikelyToCauseHarmNeglectOthers { get; set; }

        [Display ( Order = 49 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ImportanceOfTreatmentForFamilyMembers { get; set; }

        [Display ( Order = 50 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ImportanceOfTreatmentForSocialProblems { get; set; }

        [Display ( Order = 58 )]
        [Question ( QuestionType.GeneralQuestion )]
        public string InterviewerComments { get; set; }

        [Display ( Order = 51 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [UIHint ( "HighLowScale" )]
        public ScaleOf0To9 InterviewerRatingPatientNeedForFamilySocialCounseling { get; set; }

        [Display ( Order = 46 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? IsAbleToLocateAndGetToCommunityResourcesSafely { get; set; }

        [Display ( Order = 54 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto IsOutpatientMonitoringAvailable8To24Hours { get; set; }

        [Display ( Order = 52 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto IsPatientAvailableForFollowupFor7Days { get; set; }

        [Display ( Order = 56 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientMisrepresentingInformation { get; set; }

        [Display ( Order = 57 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientUnableToUnderstand { get; set; }

        [Display ( Order = 53 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto IsSupportPersonAvailableFor7Days { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto LivingArrangementAffectOnRecovery { get; set; }

        [Display ( Order = 1 )]
        public LookupDto MaritalStatus { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker MonthsInThisMaritalStatus { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker MonthsLivedInTheseArrangement { get; set; }

        [Display ( Order = 55 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public LookupDto NeedForStaffSupportToMaintainRecovery { get; set; }

        [Display ( Order = 40 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? NeglectedOrAbusedFamilyMembersDuringSubstanceUse { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfCloseFriends { get; set; }

        [Display ( Order = 36 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto PhysicalAbuseInPast30Days { get; set; }

        [Display ( Order = 44 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto RiskPatientHarmedByOther { get; set; }

        [Display ( Order = 45 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto RiskPatientHarmedByOtherOnlyDuringSubstanceUse { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoIndifferent" )]
        public LookupDto SatisfiedSpendingFreeTimeWith { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoIndifferent" )]
        public LookupDto SatisfiedWithLivingArrangement { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoIndifferent" )]
        public LookupDto SatisfiedWithThisSituation { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_SeriousConflictsWithHeader" )]
        [Range(0, 30)]
        public uint? SeriousConflictsWithFamilyInPast30Days { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "FamilyAndSocialHistorySection_SeriousConflictsWithHeader" )]
        [Range(0, 30)]
        public uint? SeriousConflictsWithNonFamilyInPast30Days { get; set; }

        [Display ( Order = 37 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SexualAbuseInPast30Days { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "Companionship" )]
        public LookupDto SpendsFreeTimeWith { get; set; }

        [Display ( Order = 47 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto TroubledByFamilyProblemsInPast30Days { get; set; }

        [Display ( Order = 48 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto TroubledBySocialProblemsInPast30Days { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LivingArrangement" )]
        public LookupDto UsualLivingArrangement { get; set; }

        #endregion
    }
}