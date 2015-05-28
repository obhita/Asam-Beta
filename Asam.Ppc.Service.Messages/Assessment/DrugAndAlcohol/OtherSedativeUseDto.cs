namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class OtherSedativeUseDto : SectionDtoBase
    {
        #region Public Properties

        [Display(Order = 36)]
        [Question(QuestionType.GeneralQuestion)]
        public bool? HasStrongUrges { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? ExperiencesWithdrawalSickness { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? FrequentlyHighAtHome { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? FrequentlyHighAtSchool { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "OtherSedativeUse_FrequentlyHighHeader", "SixColumns" )]
        public bool? FrequentlyHighAtWork { get; set; }

        [Display ( Order = 17 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "OtherSedativeUse_FrequentlyHighHeader", "SixColumns" )]
        public bool? FrequentlyHighInDangerousSituations { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 26 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasUsedSubstanceKnowingProblemsWorsened { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "OtherSedativeUse_ThinkAboutHeader" )]
        public bool? IncreasedDoseRequiredToGetSameEffect { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeMeasure LastUsed { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysUsedInPast30Days { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsUsedInLifetime { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto RouteOfIntake { get; set; }

        [Display ( Order = 25 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "OtherSedativeUse_SubstanceUseRecurrentProblemsHeader", "SixColumns" )]
        public bool? SubstanceUseRecurrentProblemsWithEmotions { get; set; }

        [Display ( Order = 21 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "OtherSedativeUse_SubstanceUseRecurrentProblemsHeader", "SixColumns" )]
        public bool? SubstanceUseRecurrentProblemsWithFamilyFriends { get; set; }

        [Display ( Order = 23 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseRecurrentProblemsWithHealth { get; set; }

        [Display ( Order = 22 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseRecurrentProblemsWithJob { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseRecurrentProblemsWithLegalSystem { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? SubstanceUseReductionAttempted { get; set; }

        [Display ( Order = 20 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "OtherSedativeUse_SubstanceUseReductionHeader", "SixColumns" )]
        public bool? SubstanceUseReductionInOccupationalActivities { get; set; }

        [Display ( Order = 19 )]
        [Question ( QuestionType.GeneralQuestion )]
        public bool? SubstanceUseReductionInRecreationalActivities { get; set; }

        [Display ( Order = 18 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "OtherSedativeUse_SubstanceUseReductionHeader", "SixColumns" )]
        public bool? SubstanceUseReductionInSocialActivities { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "OtherSedativeUse_ThinkAboutHeader" )]
        public bool? UnableToStopUsingSubstance { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? UseOfSubstanceTakesUpALotOfTime { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? UseSubstanceToPreventWithdrawalSickness { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "SubstanceTakenAsPrescribed" )]
        public LookupDto WasSubstanceTakenAsPrescribed { get; set; }

        #endregion
    }
}