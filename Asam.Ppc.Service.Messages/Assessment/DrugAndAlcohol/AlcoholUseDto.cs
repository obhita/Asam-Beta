namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class AlcoholUseDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto AlcoholRouteOfIntake { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "AlcoholRouteOfIntake" )]
        public LookupDto AlcoholToIntoxicationRouteOfIntake { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? AlcoholUsedToIntoxication { get; set; }

        [Display ( Order = 34 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public MoneyDto AmountOfMoneySpentInLast30Days { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? ExperiencesWithdrawalSickness { get; set; }

        [Display ( Order = 20 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? FrequentlyHighAtHome { get; set; }

        [Display ( Order = 21 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? FrequentlyHighAtSchool { get; set; }

        [Display ( Order = 19 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "AlcoholUse_FrequentlyHeader", "SixColumns" )]
        public bool? FrequentlyHighAtWork { get; set; }

        [Display ( Order = 22 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "AlcoholUse_FrequentlyHeader", "SixColumns" )]
        public bool? FrequentlyHighInDangerousSituations { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 31 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasUsedSubstanceKnowingProblemsWorsened { get; set; }

        [Display ( Order = 35 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ImportanceOfTreatmentForSubstanceProblems { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "AlcoholUse_ThinkAboutAlcoholHeader" )]
        public bool? IncreasedDoseRequiredToGetSameEffect { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeMeasure LastUsed { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeMeasure LastUsedToIntoxification { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysIntoxicatedInPast30Days { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysUsedInPast30Days { get; set; }

        [Display ( Order = 34 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range (0, 30)]
        public uint? NumberOfDaysWithSubstanceProblemsInLast30Days { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsAsAlcoholConsumerToIntoxication { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsUsedInLifetime { get; set; }

        [Display ( Order = 32 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfTimesWithdrawalCausedDeliriumTremens { get; set; }

        [Display ( Order = 33 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfTimesWithdrawalCausedSeizures { get; set; }

        [Display ( Order = 30 )]
        [QuestionGroup ( "AlcoholUse_SubstanceUseRecurrentHeader", "SixColumns" )]
        public bool? SubstanceUseRecurrentProblemsWithEmotions { get; set; }

        [Display ( Order = 26 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "AlcoholUse_SubstanceUseRecurrentHeader", "SixColumns" )]
        public bool? SubstanceUseRecurrentProblemsWithFamilyFriends { get; set; }

        [Display ( Order = 28 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseRecurrentProblemsWithHealth { get; set; }

        [Display ( Order = 27 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseRecurrentProblemsWithJob { get; set; }

        [Display ( Order = 29 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseRecurrentProblemsWithLegalSystem { get; set; }

        [Display ( Order = 17 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? SubstanceUseReductionAttempted { get; set; }

        [Display ( Order = 25 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "AlcoholUse_SubstanceUseReductionHeader", "SixColumns" )]
        public bool? SubstanceUseReductionInOccupationalActivities { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseReductionInRecreationalActivities { get; set; }

        [Display ( Order = 23 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "AlcoholUse_SubstanceUseReductionHeader", "SixColumns" )]
        public bool? SubstanceUseReductionInSocialActivities { get; set; }

        [Display ( Order = 34 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto TroubledInLast30DaysBySubstanceProblems { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "AlcoholUse_ThinkAboutAlcoholHeader" )]
        public bool? UnableToStopUsingSubstance { get; set; }

        [Display ( Order = 18 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? UseOfSubstanceTakesUpALotOfTime { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? UseSubstanceToPreventWithdrawalSickness { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "SubstanceTakenAsPrescribed" )]
        public LookupDto WasSubstanceTakenAsPrescribed { get; set; }

        [Display(Order = 36)]
        [Question(QuestionType.GeneralQuestion)]
        public bool? HasStrongUrges { get; set; }

        #endregion
    }
}