namespace Asam.Ppc.Service.Messages.Assessment.Legal
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class LegalSectionDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 26 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LegalCharge" )]
        public LookupDto CurrentlyAwaitingChargesTrialSentenceForLegalCharge { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "DesireAndExternalFactorsDrivingTreatment" )]
        public LookupDto DesireAndExternalFactorsDrivingTreatment { get; set; }

        [Display ( Order = 29 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ImportanceOfCounselingForCurrentLegalProblems { get; set; }

        [Display ( Order = 32 )]
        [Question ( QuestionType.GeneralQuestion )]
        public string InterviewerComments { get; set; }

        [Display ( Order = 30 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [UIHint ( "HighLowScale" )]
        public ScaleOf0To9 InterviewerRatingPatientNeedForLegalServiceCounseling { get; set; }

        [Display ( Order = 25 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? IsCurrentlyAwaitingChargesTrialSentence { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? IsOnProbationOrParole { get; set; }

        [Display ( Order = 31 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientMisrepresentingInformation { get; set; }

        [Display ( Order = 32 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientUnableToUnderstand { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LegalCharge" )]
        public LookupDto LastIncarcerationReason { get; set; }

        [Display ( Order = 23 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker LengthInMonthsOfLastIncarceration { get; set; }

        [Display ( Order = 27 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysCommitingCrimesForProfitInPast30Days { get; set; }

        [Display ( Order = 22 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfDaysIncarceratedInPast30Days { get; set; }

        [Display ( Order = 21 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsIncarceratedInLife { get; set; }

        [Display ( Order = 11 )]
        public uint? NumberOfTimesArrestedForArson { get; set; }

        [Display ( Order = 10 )]
        public uint? NumberOfTimesArrestedForAssault { get; set; }

        [Display ( Order = 8 )]
        public uint? NumberOfTimesArrestedForBurglaryLarceny { get; set; }

        [Display ( Order = 15 )]
        public uint? NumberOfTimesArrestedForContemptOfCourt { get; set; }

        [Display ( Order = 6 )]
        public uint? NumberOfTimesArrestedForDrugCharges { get; set; }

        [Display ( Order = 7 )]
        public uint? NumberOfTimesArrestedForForgery { get; set; }

        [Display ( Order = 13 )]
        public uint? NumberOfTimesArrestedForHomicide { get; set; }

        [Display ( Order = 16 )]
        public uint? NumberOfTimesArrestedForOtherArrest { get; set; }

        [Display ( Order = 5 )]
        public uint? NumberOfTimesArrestedForParoleProbationViolation { get; set; }

        [Display ( Order = 14 )]
        public uint? NumberOfTimesArrestedForProstitution { get; set; }

        [Display ( Order = 12 )]
        public uint? NumberOfTimesArrestedForRape { get; set; }

        [Display ( Order = 9 )]
        public uint? NumberOfTimesArrestedForRobbery { get; set; }

        [Display ( Order = 4 )]
        [QuestionGroup ( "LegalSection_NumberOfTimesArrestedHeader" )]
        public uint? NumberOfTimesArrestedForShopliftingVandalism { get; set; }

        [Display ( Order = 8 )]
        public uint? NumberOfTimesArrestedForWeaponsOffense { get; set; }

        [Display ( Order = 18 )]
        [QuestionGroup ( "LegalSection_NumberOfTimesChargedHeader" )]
        public uint? NumberOfTimesChargedWithDisorderlyConductVagrancyIntoxication { get; set; }

        [Display ( Order = 19 )]
        public uint? NumberOfTimesChargedWithDrivingWhileIntoxicated { get; set; }

        [Display ( Order = 20 )]
        [QuestionGroup ( "LegalSection_NumberOfTimesChargedHeader" )]
        public uint? NumberOfTimesChargedWithMajorDrivingViolations { get; set; }

        [Display ( Order = 17 )]
        [QuestionGroup ( "LegalSection_NumberOfTimesArrestedHeader" )]
        public uint? NumberOfTimesConvicted { get; set; }

        [Display ( Order = 28 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SeverityOfCurrentLegalProblems { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? WasVisitPromptedByCriminalJusticeSystem { get; set; }

        #endregion
    }
}