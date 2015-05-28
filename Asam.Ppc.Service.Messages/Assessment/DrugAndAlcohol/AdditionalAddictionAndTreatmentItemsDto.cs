namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class AdditionalAddictionAndTreatmentItemsDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "IncreaseInAddictionSymptoms" )]
        public LookupDto AddictionSymptomsIncreasedRecently { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "ConcernsAboutPursuingTreatment" )]
        public LookupDto ConcernsAboutPursuingTreatment { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto CurrentStrengthOfSubstanceUseDesire { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "SubstanceUseOrRelapseLikelihood" )]
        public LookupDto FeelLikelyToContinueSubstanceUseOrRelapse { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto HelpfulnessOfTreatment { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto LikelihoodPreviousEnvironmentWillInduceSubstanceUse { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsSinceAbstinenceEndFromSubstance { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfTimesOverdosedOnDrugs { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RelapseCause" )]
        public LookupDto PossibleFutureRelapseCause { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RelapsePreventionStrategies" )]
        public LookupDto StrategyToPreventRelapse { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SubstanceOverdoseInPast24Hours { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "ProblemSubstance" )]
        public LookupDto WhichSubstanceIsMajorProblem { get; set; }

        #endregion
    }
}