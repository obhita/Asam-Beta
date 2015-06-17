using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Primitives;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    using Pillar.Domain.Attributes;

    /// <summary>
    /// Family and social history section.
    /// </summary>
    public class FamilyAndSocialHistorySection : RevisionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FamilyAndSocialHistorySection" /> class.
        /// </summary>
        protected internal FamilyAndSocialHistorySection()
        {
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the closest contacts needs and willingness to help treatment.
        /// </summary>
        /// <value>
        /// The closest contacts needs and willingness to help treatment.
        /// </value>
        public virtual NeedsAndWillingnessToHelpTreatment ClosestContactsNeedsAndWillingnessToHelpTreatment { get; protected set; }

        /// <summary>
        /// Gets the closest personal contact in past4 months.
        /// </summary>
        /// <value>
        /// The closest personal contact in past4 months.
        /// </value>
        public virtual ContactPerson ClosestPersonalContactInPast4Months { get; protected set; }

        /// <summary>
        /// Gets the deals with problems from friends that risk relapse.
        /// </summary>
        /// <value>
        /// The deals with problems from friends that risk relapse.
        /// </value>
        public virtual StrategiesToDealWithProblemsFromFriendsThatRiskRelapse
            DealsWithProblemsFromFriendsThatRiskRelapse { get; protected set; }

        /// <summary>
        /// Gets the deals with problems in free time that risk relapse.
        /// </summary>
        /// <value>
        /// The deals with problems in free time that risk relapse.
        /// </value>
        public virtual StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse DealsWithProblemsInFreeTimeThatRiskRelapse { get; protected set; }

        /// <summary>
        /// Gets the emotional abuse in past30 days.
        /// </summary>
        /// <value>
        /// The emotional abuse in past30 days.
        /// </value>
        public virtual LikertScale EmotionalAbuseInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the family neglect or abuse will worsen without greater than care level_ II.
        /// </summary>
        /// <value>
        /// The family neglect or abuse will worsen without greater than care level_ II.
        /// </value>
        public virtual LikertScale FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II { get; protected set; }

        /// <summary>
        /// Gets the free time affect on recovery.
        /// </summary>
        /// <value>
        /// The free time affect on recovery.
        /// </value>
        public virtual FreeTimeAffectOnRecovery FreeTimeAffectOnRecovery { get; protected set; }

        /// <summary>
        /// Gets the friends affect on recovery.
        /// </summary>
        /// <value>
        /// The friends affect on recovery.
        /// </value>
        public virtual FriendsAffectOnRecovery FriendsAffectOnRecovery { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with children.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with children.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithChildren { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with close friends.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with close friends.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithCloseFriends { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with coworkers.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with coworkers.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithCoworkers { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with father.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with father.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithFather { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with mother.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with mother.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithMother { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with neighbors.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with neighbors.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithNeighbors { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with other family.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with other family.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithOtherFamily { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with sex partner.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with sex partner.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithSexPartner { get; protected set; }

        /// <summary>
        /// Gets the had problems in lifetime with sibling.
        /// </summary>
        /// <value>
        /// The had problems in lifetime with sibling.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInLifetimeWithSibling { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with children.
        /// </summary>
        /// <value>
        /// The had problems in past month with children.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithChildren { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with close friends.
        /// </summary>
        /// <value>
        /// The had problems in past month with close friends.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithCloseFriends { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with coworkers.
        /// </summary>
        /// <value>
        /// The had problems in past month with coworkers.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithCoworkers { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with father.
        /// </summary>
        /// <value>
        /// The had problems in past month with father.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithFather { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with mother.
        /// </summary>
        /// <value>
        /// The had problems in past month with mother.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithMother { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with neighbors.
        /// </summary>
        /// <value>
        /// The had problems in past month with neighbors.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithNeighbors { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with other family.
        /// </summary>
        /// <value>
        /// The had problems in past month with other family.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithOtherFamily { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with sex partner.
        /// </summary>
        /// <value>
        /// The had problems in past month with sex partner.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithSexPartner { get; protected set; }

        /// <summary>
        /// Gets the had problems in past month with sibling.
        /// </summary>
        /// <value>
        /// The had problems in past month with sibling.
        /// </value>
        public virtual YesNoNotApplicable HadProblemsInPastMonthWithSibling { get; protected set; }

        /// <summary>
        /// Gets the has recently neglected or abused family members.
        /// </summary>
        /// <value>
        /// The has recently neglected or abused family members.
        /// </value>
        public virtual LikertScale HasRecentlyNeglectedOrAbusedFamilyMembers { get; protected set; }

        /// <summary>
        /// Gets the how likely to cause harm neglect others.
        /// </summary>
        /// <value>
        /// The how likely to cause harm neglect others.
        /// </value>
        public virtual LikertScale HowLikelyToCauseHarmNeglectOthers { get; protected set; }

        /// <summary>
        /// Gets the importance of treatment for family members.
        /// </summary>
        /// <value>
        /// The importance of treatment for family members.
        /// </value>
        public virtual LikertScale ImportanceOfTreatmentForFamilyMembers { get; protected set; }

        /// <summary>
        /// Gets the importance of treatment for social problems.
        /// </summary>
        /// <value>
        /// The importance of treatment for social problems.
        /// </value>
        public virtual LikertScale ImportanceOfTreatmentForSocialProblems { get; protected set; }

        /// <summary>
        /// Gets the interviewer comments.
        /// </summary>
        /// <value>
        /// The interviewer comments.
        /// </value>
        [ColumnLength(2000)]
        public virtual string InterviewerComments { get; protected set; }

        /// <summary>
        /// Gets the interviewer rating patient need for family social counseling.
        /// </summary>
        /// <value>
        /// The interviewer rating patient need for family social counseling.
        /// </value>
        public virtual ScaleOf0To9 InterviewerRatingPatientNeedForFamilySocialCounseling { get; protected set; }

        /// <summary>
        /// Gets the is able to locate and get to community resources safely.
        /// </summary>
        /// <value>
        /// The is able to locate and get to community resources safely.
        /// </value>
        public virtual bool? IsAbleToLocateAndGetToCommunityResourcesSafely { get; protected set; }

        /// <summary>
        /// Gets the is outpatient monitoring available8 to24 hours.
        /// </summary>
        /// <value>
        /// The is outpatient monitoring available8 to24 hours.
        /// </value>
        public virtual YesNoNotSure IsOutpatientMonitoringAvailable8To24Hours { get; protected set; }

        /// <summary>
        /// Gets the is patient available for followup for7 days.
        /// </summary>
        /// <value>
        /// The is patient available for followup for7 days.
        /// </value>
        public virtual YesNoNotSure IsPatientAvailableForFollowupFor7Days { get; protected set; }

        /// <summary>
        /// Gets the is patient misrepresenting information.
        /// </summary>
        /// <value>
        /// The is patient misrepresenting information.
        /// </value>
        public virtual bool? IsPatientMisrepresentingInformation { get; protected set; }

        /// <summary>
        /// Gets the is patient unable to understand.
        /// </summary>
        /// <value>
        /// The is patient unable to understand.
        /// </value>
        public virtual bool? IsPatientUnableToUnderstand { get; protected set; }

        /// <summary>
        /// Gets the is support person available for7 days.
        /// </summary>
        /// <value>
        /// The is support person available for7 days.
        /// </value>
        public virtual YesNoNotSure IsSupportPersonAvailableFor7Days { get; protected set; }

        /// <summary>
        /// Gets the living arrangement affect on recovery.
        /// </summary>
        /// <value>
        /// The living arrangement affect on recovery.
        /// </value>
        public virtual LivingArrangementAffectOnRecovery LivingArrangementAffectOnRecovery { get; protected set; }

        /// <summary>
        /// Gets the marital status.
        /// </summary>
        /// <value>
        /// The marital status.
        /// </value>
        public virtual MaritalStatus MaritalStatus { get; protected set; }

        /// <summary>
        /// Gets the months in this marital status.
        /// </summary>
        /// <value>
        /// The months in this marital status.
        /// </value>
        public virtual uint? MonthsInThisMaritalStatus { get; protected set; }

        /// <summary>
        /// Gets the months lived in these arrangement.
        /// </summary>
        /// <value>
        /// The months lived in these arrangement.
        /// </value>
        public virtual uint? MonthsLivedInTheseArrangement { get; protected set; }

        /// <summary>
        /// Gets the need for staff support to maintain recovery.
        /// </summary>
        /// <value>
        /// The need for staff support to maintain recovery.
        /// </value>
        public virtual NeedForStaffSupportToMaintainRecovery NeedForStaffSupportToMaintainRecovery { get; protected set; }

        /// <summary>
        /// Gets the neglected or abused family members during substance use.
        /// </summary>
        /// <value>
        /// The neglected or abused family members during substance use.
        /// </value>
        public virtual bool? NeglectedOrAbusedFamilyMembersDuringSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the number of close friends.
        /// </summary>
        /// <value>
        /// The number of close friends.
        /// </value>
        public virtual uint? NumberOfCloseFriends { get; protected set; }

        /// <summary>
        /// Gets the physical abuse in past30 days.
        /// </summary>
        /// <value>
        /// The physical abuse in past30 days.
        /// </value>
        public virtual LikertScale PhysicalAbuseInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the risk patient harmed by other.
        /// </summary>
        /// <value>
        /// The risk patient harmed by other.
        /// </value>
        public virtual LikertScale RiskPatientHarmedByOther { get; protected set; }

        /// <summary>
        /// Gets the risk patient harmed by other only during substance use.
        /// </summary>
        /// <value>
        /// The risk patient harmed by other only during substance use.
        /// </value>
        public virtual LikertScale RiskPatientHarmedByOtherOnlyDuringSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the satisfied spending free time with.
        /// </summary>
        /// <value>
        /// The satisfied spending free time with.
        /// </value>
        public virtual YesNoIndifferent SatisfiedSpendingFreeTimeWith { get; protected set; }

        /// <summary>
        /// Gets the satisfied with living arrangement.
        /// </summary>
        /// <value>
        /// The satisfied with living arrangement.
        /// </value>
        public virtual YesNoIndifferent SatisfiedWithLivingArrangement { get; protected set; }

        /// <summary>
        /// Gets the satisfied with this situation.
        /// </summary>
        /// <value>
        /// The satisfied with this situation.
        /// </value>
        public virtual YesNoIndifferent SatisfiedWithThisSituation { get; protected set; }

        /// <summary>
        /// Gets the serious conflicts with family in past30 days.
        /// </summary>
        /// <value>
        /// The serious conflicts with family in past30 days.
        /// </value>
        public virtual uint? SeriousConflictsWithFamilyInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the serious conflicts with non family in past30 days.
        /// </summary>
        /// <value>
        /// The serious conflicts with non family in past30 days.
        /// </value>
        public virtual uint? SeriousConflictsWithNonFamilyInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the sexual abuse in past30 days.
        /// </summary>
        /// <value>
        /// The sexual abuse in past30 days.
        /// </value>
        public virtual LikertScale SexualAbuseInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the spends free time with.
        /// </summary>
        /// <value>
        /// The spends free time with.
        /// </value>
        public virtual Companionship SpendsFreeTimeWith { get; protected set; }

        /// <summary>
        /// Gets the troubled by family problems in past30 days.
        /// </summary>
        /// <value>
        /// The troubled by family problems in past30 days.
        /// </value>
        public virtual LikertScale TroubledByFamilyProblemsInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the troubled by social problems in past30 days.
        /// </summary>
        /// <value>
        /// The troubled by social problems in past30 days.
        /// </value>
        public virtual LikertScale TroubledBySocialProblemsInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the usual living arrangement.
        /// </summary>
        /// <value>
        /// The usual living arrangement.
        /// </value>
        public virtual LivingArrangement UsualLivingArrangement { get; protected set; }

        #endregion
    }
}