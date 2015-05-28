namespace Asam.Ppc.Service.Messages.Assessment.EmploymentAndSupport
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class EmploymentAndSupportSectionDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 14 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "EmploymentAndSupportSection_MoneyHeader", "SixColumns" )]
        public MoneyDto AmountOfMoneyInPast30DaysFromEmployment { get; set; }

        [Display ( Order = 19 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "EmploymentAndSupportSection_MoneyHeader", "SixColumns" )]
        public MoneyDto AmountOfMoneyInPast30DaysFromIllegalMeans { get; set; }

        [Display ( Order = 17 )]
        [Question ( QuestionType.GeneralQuestion )]
        public MoneyDto AmountOfMoneyInPast30DaysFromMateFamilyFriends { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.GeneralQuestion )]
        public MoneyDto AmountOfMoneyInPast30DaysFromPensionOrBenefits { get; set; }

        [Display ( Order = 18 )]
        [Question ( QuestionType.GeneralQuestion )]
        public MoneyDto AmountOfMoneyInPast30DaysFromPublicAssistance { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.GeneralQuestion )]
        public MoneyDto AmountOfMoneyInPast30DaysFromUnemployment { get; set; }

        [Display ( Order = 22 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ConcernAboutEmploymentProblemsInPast30Days { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker EducationInMonths { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "EmploymentPattern" )]
        public LookupDto EmploymentPatternInPast3Years { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasAutomobileAvailableForUse { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasProfessionalTradeOrSkill { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasValidDriversLicense { get; set; }

        [Display ( Order = 23 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ImportanceOfCounselingForEmploymentProblems { get; set; }

        [Display ( Order = 27 )]
        [Question ( QuestionType.GeneralQuestion )]
        public string InterviewerComments { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [UIHint ( "HighLowScale" )]
        public ScaleOf0To9 InterviewerRatingPatientNeedForEmploymentCounseling { get; set; }

        [Display ( Order = 25 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientMisrepresentingInformation { get; set; }

        [Display ( Order = 26 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientUnableToUnderstand { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker LongestTimeWithoutJobInMonths { get; set; }

        [Display ( Order = 21 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysWithEmploymentProblemsInPast30Days { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysWorkingInPast30Days { get; set; }

        [Display ( Order = 20 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfDependents { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public string ProfessionalTradeOrSkillDescription { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? ReceivesFinancialSupportFromOtherPerson { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? ReceivesMajorityOfFinancialSupportFromOtherPerson { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker TrainingOrTechnicalEducationInMonths { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public string UsualOrLastOccupationDescription { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto WorkOrSchoolAffectOnRecovery { get; set; }

        #endregion
    }
}