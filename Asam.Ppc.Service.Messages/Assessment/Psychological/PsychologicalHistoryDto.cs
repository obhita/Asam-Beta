namespace Asam.Ppc.Service.Messages.Assessment.Psychological
{
    #region Using Statements

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class PsychologicalHistoryDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 51 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChestPainsInLast24Hours { get; set; }

        [Display ( Order = 50 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChestPainsInLastMonth { get; set; }

        [Display ( Order = 49 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackChestPainsHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChestPainsInLifetime { get; set; }

        [Display ( Order = 52 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackChestPainsHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackChestPainsRelatedToSubstanceUse { get; set; }

        [Display ( Order = 87 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChillsHotFlashesInLast24Hours { get; set; }

        [Display ( Order = 86 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChillsHotFlashesInLastMonth { get; set; }

        [Display ( Order = 85 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackChillsHotFlashesHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChillsHotFlashesInLifetime { get; set; }

        [Display ( Order = 88 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackChillsHotFlashesHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackChillsHotFlashesRelatedToSubstanceUse { get; set; }

        [Display ( Order = 59 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChokingInLast24Hours { get; set; }

        [Display ( Order = 58 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChokingInLastMonth { get; set; }

        [Display ( Order = 57 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackChokingHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackChokingInLifetime { get; set; }

        [Display ( Order = 60 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackChokingHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackChokingRelatedToSubstanceUse { get; set; }

        [Display ( Order = 79 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDistortedRealityInLast24Hours { get; set; }

        [Display ( Order = 78 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDistortedRealityInLastMonth { get; set; }

        [Display ( Order = 77 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackDistortedRealityHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDistortedRealityInLifetime { get; set; }

        [Display ( Order = 80 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackDistortedRealityHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackDistortedRealityRelatedToSubstanceUse { get; set; }

        [Display ( Order = 75 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDizzinessFaintnessInLast24Hours { get; set; }

        [Display ( Order = 74 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDizzinessFaintnessInLastMonth { get; set; }

        [Display ( Order = 73 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackDizzinessFaintnessHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDizzinessFaintnessInLifetime { get; set; }

        [Display ( Order = 76 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackDizzinessFaintnessHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackDizzinessFaintnessRelatedToSubstanceUse { get; set; }

        [Display ( Order = 95 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDyingSensationInLast24Hours { get; set; }

        [Display ( Order = 94 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDyingSensationInLastMonth { get; set; }

        [Display ( Order = 93 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackDyingSensationHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackDyingSensationInLifetime { get; set; }

        [Display ( Order = 96 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackDyingSensationHeader", 0 )]
        [QuestionGroup ( "PsychologicalHistory_AttacksGiveYouHeader", 1 )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackDyingSensationRelatedToSubstanceUse { get; set; }

        [Display ( Order = 31 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackInLast24Hours { get; set; }

        [Display ( Order = 30 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackInLastMonth { get; set; }

        [Display ( Order = 29 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackInLifetime { get; set; }

        [Display ( Order = 91 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackLoseControlInLast24Hours { get; set; }

        [Display ( Order = 90 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackLoseControlInLastMonth { get; set; }

        [Display ( Order = 89 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackLoseControlHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackLoseControlInLifetime { get; set; }

        [Display ( Order = 92 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackLoseControlHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackLoseControlRelatedToSubstanceUse { get; set; }

        [Display ( Order = 35 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackMoreThanOnceInLast24Hours { get; set; }

        [Display ( Order = 34 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackMoreThanOnceInLastMonth { get; set; }

        [Display ( Order = 33 )]
        [QuestionGroup ( "PsychologicalHistory_RegardingAnxietyAttackHeader", 0 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackMoreThanOnceHeader", 1 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackMoreThanOnceInLifetime { get; set; }

        [Display ( Order = 36 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackMoreThanOnceHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackMoreThanOnceRelatedToSubstanceUse { get; set; }

        [Display ( Order = 71 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackNauseaDiarrheaInLast24Hours { get; set; }

        [Display ( Order = 70 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackNauseaDiarrheaInLastMonth { get; set; }

        [Display ( Order = 69 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackNauseaDiarrheaHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackNauseaDiarrheaInLifetime { get; set; }

        [Display ( Order = 72 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackNauseaDiarrheaHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackNauseaDiarrheaRelatedToSubstanceUse { get; set; }

        [Display ( Order = 83 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackNumbnessInLast24Hours { get; set; }

        [Display ( Order = 82 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackNumbnessInLastMonth { get; set; }

        [Display ( Order = 81 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackNumbnessHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackNumbnessInLifetime { get; set; }

        [Display ( Order = 84 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackNumbnessHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackNumbnessRelatedToSubstanceUse { get; set; }

        [Display ( Order = 47 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackPalpitationsInLast24Hours { get; set; }

        [Display ( Order = 46 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackPalpitationsInLastMonth { get; set; }

        [Display ( Order = 45 )]
        [QuestionGroup ( "PsychologicalHistory_AttacksGiveYouHeader", 0 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackPalpitationsHeader", 1 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackPalpitationsInLifetime { get; set; }

        [Display ( Order = 48 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackPalpitationsHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackPalpitationsRelatedToSubstanceUse { get; set; }

        [Display ( Order = 39 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackRandomInLast24Hours { get; set; }

        [Display ( Order = 38 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackRandomInLastMonth { get; set; }

        [Display ( Order = 37 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackRandomHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackRandomInLifetime { get; set; }

        [Display ( Order = 40 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackRandomHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackRandomRelatedToSubstanceUse { get; set; }

        [Display ( Order = 55 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackShortnessBreathInLast24Hours { get; set; }

        [Display ( Order = 54 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackShortnessBreathInLastMonth { get; set; }

        [Display ( Order = 53 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackShortnessBreathHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackShortnessBreathInLifetime { get; set; }

        [Display ( Order = 56 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackShortnessBreathHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackShortnessBreathRelatedToSubstanceUse { get; set; }

        [Display ( Order = 63 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackSweatyInLast24Hours { get; set; }

        [Display ( Order = 62 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackSweatyInLastMonth { get; set; }

        [Display ( Order = 61 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackSweatyHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackSweatyInLifetime { get; set; }

        [Display ( Order = 64 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackSweatyHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackSweatyRelatedToSubstanceUse { get; set; }

        [Display ( Order = 67 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackTremblingInLast24Hours { get; set; }

        [Display ( Order = 66 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackTremblingInLastMonth { get; set; }

        [Display ( Order = 65 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackTremblingHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyAttackTremblingInLifetime { get; set; }

        [Display ( Order = 68 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackTremblingHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackTremblingRelatedToSubstanceUse { get; set; }

        [Display ( Order = 32 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodExperiencedHeaderNoDrugAlcohol", 1 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyAttackHeader", 0 )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyAttackWithin24HoursRelatedToSubstanceUse { get; set; }

        [Display ( Order = 27 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyTensionWorryInLast24Hours { get; set; }

        [Display ( Order = 26 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyTensionWorryInLastMonth { get; set; }

        [Display ( Order = 25 )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyTensionWorryHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto AnxietyTensionWorryInLifetime { get; set; }

        [Display ( Order = 28 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_AnxietyTensionWorryHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto AnxietyTensionWorryWithin24HoursRelatedToSubstanceUse { get; set; }

        [Display ( Order = 180 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? CantWaitForThingsWantedBadly { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodOfSeriousDepressionHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto DepressionWithin24HoursRelatedToSubstanceUse { get; set; }

        [Display ( Order = 181 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? DifficultToWorkNowForFutureGain { get; set; }

        [Display ( Order = 173 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "EmotionalProblemsCorrelationWithSubstanceUse" )]
        public LookupDto EmotionalProblemsCorrelationWithSubstanceUse { get; set; }

        [Display ( Order = 19 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto FeelLikeFailureInLast24Hours { get; set; }

        [Display ( Order = 20 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_FeelLikeFailureHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto FeelLikeFailureInLast24HoursRelatedToSubstanceUse { get; set; }

        [Display ( Order = 18 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto FeelLikeFailureInLastMonth { get; set; }

        [Display ( Order = 17 )]
        [QuestionGroup ( "PsychologicalHistory_FeelLikeFailureHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto FeelLikeFailureInLifetime { get; set; }

        [Display ( Order = 176 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "ProblemsForWorkHomeAndSocialInteractionScale" )]
        public LookupDto HowDifficultProblemsForWorkHomeAndSocialInteraction { get; set; }

        [Display ( Order = 179 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [QuestionGroup ( "PsychologicalHistory_HowDifficultToSelfManageEmotionalProblemsHeader" )]
        [QuestionGroup ( "PsychologicalHistory_HowDifficultToSelfManageEmotionalProblemsHeader" )]
        [LookupCategory ( "SelfManageEmotionalProblemsScale" )]
        public LookupDto HowDifficultToSelfManageEmotionalProblems { get; set; }

        [Display ( Order = 178 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "EmotionalProblemsImpactRecoveryEffortsScale" )]
        public LookupDto HowEmotionalProblemsImpactRecoveryEfforts { get; set; }

        [Display ( Order = 177 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "PsychologicalEmotionalCounselingImportanceScale" )]
        public LookupDto HowImportantPsychologicalEmotionalCounseling { get; set; }

        [Display ( Order = 174 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto HowTroubledByPsychologicalEmotionalProblemsLast30Days { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto InabilityToFeelPleasureFromActivitiesInLast24Hours { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto InabilityToFeelPleasureFromActivitiesInLastMonth { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_InabilityToFeelPleasureFromActivitiesHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto InabilityToFeelPleasureFromActivitiesInLifetime { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        [QuestionGroup ( "PsychologicalHistory_InabilityToFeelPleasureFromActivitiesHeader" )]
        public LookupDto InabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse { get; set; }

        [Display ( Order = 172 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto IsReceivingNeededCare { get; set; }

        [Display ( Order = 171 )]
        [QuestionGroup ( "PsychologicalHistory_MedicatedForPsychologicalEmotionalProblemHeader" )]
        public bool? MedicatedForPsychologicalEmotionalProblemInLast24Hours { get; set; }

        [Display ( Order = 170 )]
        public bool? MedicatedForPsychologicalEmotionalProblemInLastMonth { get; set; }

        [Display ( Order = 169 )]
        [QuestionGroup ( "PsychologicalHistory_MedicatedForPsychologicalEmotionalProblemHeader" )]
        public bool? MedicatedForPsychologicalEmotionalProblemInLifetime { get; set; }

        [Display ( Order = 23 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto MovingSpeakingSlowlyInLast24Hours { get; set; }

        [Display ( Order = 22 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto MovingSpeakingSlowlyInLastMonth { get; set; }

        [Display ( Order = 21 )]
        [QuestionGroup ( "PsychologicalHistory_MovingSpeakingSlowlyHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto MovingSpeakingSlowlyInLifetime { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        [QuestionGroup ( "PsychologicalHistory_MovingSpeakingSlowlyHeader" )]
        public LookupDto MovingSpeakingSlowlyWithin24HoursRelatedToSubstanceUse { get; set; }

        [Display ( Order = 175 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysExperiencedPsychologicalEmotionalProblemsInLast30Days { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "PsychologicalOrEmotionalProblems" )]
        public IEnumerable<LookupDto> PastPsychologicalOrEmotionalProblems { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto PoorAppetiteOrOvereatingInLast24Hours { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_PoorAppetiteOvereatingHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto PoorAppetiteOrOvereatingInLast24HoursRelatedToSubstanceUse { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto PoorAppetiteOrOvereatingInLastMonth { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "PsychologicalHistory_PoorAppetiteOvereatingHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto PoorAppetiteOrOvereatingInLifetime { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? ReceivesPensionForPsychiatricDisability { get; set; }

        [Display ( Order = 167 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodAttemptedSuicideInLast24Hours { get; set; }

        [Display ( Order = 166 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodAttemptedSuicideInLastMonth { get; set; }

        [Display ( Order = 165 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodAttemptedSuicideHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodAttemptedSuicideInLifetime { get; set; }

        [Display ( Order = 168 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodAttemptedSuicideHeader", 0 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodExperiencedHeader", 1 )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodAttemptedSuicideRelatedToSubstanceUse { get; set; }

        [Display ( Order = 147 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodCurbingViolentBehaviorInLast24Hours { get; set; }

        [Display ( Order = 146 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodCurbingViolentBehaviorInLastMonth { get; set; }

        [Display ( Order = 145 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodCurbingViolentBehaviorHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodCurbingViolentBehaviorInLifetime { get; set; }

        [Display ( Order = 148 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodCurbingViolentBehaviorHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUse { get; set; }

        [Display ( Order = 119 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodExcessiveBehaviorInLast24Hours { get; set; }

        [Display ( Order = 118 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodExcessiveBehaviorInLastMonth { get; set; }

        [Display ( Order = 117 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodExcessiveBehaviorHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodExcessiveBehaviorInLifetime { get; set; }

        [Display ( Order = 120 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodExcessiveBehaviorHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodExcessiveBehaviorRelatedToSubstanceUse { get; set; }

        [Display ( Order = 99 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodFidgetingInLast24Hours { get; set; }

        [Display ( Order = 98 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodFidgetingInLastMonth { get; set; }

        [Display ( Order = 97 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodExperiencedHeader", 0 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodFidgetingHeader", 1 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodFidgetingInLifetime { get; set; }

        [Display ( Order = 100 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodFidgetingHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodFidgetingRelatedToSubstanceUse { get; set; }

        [Display ( Order = 135 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodFlashbacksInLast24Hours { get; set; }

        [Display ( Order = 134 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodFlashbacksInLastMonth { get; set; }

        [Display ( Order = 133 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodFlashbacksHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodFlashbacksInLifetime { get; set; }

        [Display ( Order = 136 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodFlashbacksHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodFlashbacksRelatedToSubstanceUse { get; set; }

        [Display ( Order = 131 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodHallucinationsInLast24Hours { get; set; }

        [Display ( Order = 130 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodHallucinationsInLastMonth { get; set; }

        [Display ( Order = 129 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodHallucinationsHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodHallucinationsInLifetime { get; set; }

        [Display ( Order = 132 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodHallucinationsHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodHallucinationsRelatedToSubstanceUse { get; set; }

        [Display ( Order = 139 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodImpairedThoughtInLast24Hours { get; set; }

        [Display ( Order = 138 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodImpairedThoughtInLastMonth { get; set; }

        [Display ( Order = 137 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodImpairedThoughtHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodImpairedThoughtInLifetime { get; set; }

        [Display ( Order = 140 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodImpairedThoughtHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodImpairedThoughtRelatedToSubstanceUse { get; set; }

        [Display ( Order = 143 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodIrritabilityInLast24Hours { get; set; }

        [Display ( Order = 142 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodIrritabilityInLastMonth { get; set; }

        [Display ( Order = 141 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodIrritabilityHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodIrritabilityInLifetime { get; set; }

        [Display ( Order = 144 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodIrritabilityHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodIrritabilityRelatedToSubstanceUse { get; set; }

        [Display ( Order = 107 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodLethargyInLast24Hours { get; set; }

        [Display ( Order = 106 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodLethargyInLastMonth { get; set; }

        [Display ( Order = 105 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodLethargyHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodLethargyInLifetime { get; set; }

        [Display ( Order = 108 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodLethargyHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodLethargyRelatedToSubstanceUse { get; set; }

        [Display ( Order = 111 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodMuscleTensionInLast24Hours { get; set; }

        [Display ( Order = 110 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodMuscleTensionInLastMonth { get; set; }

        [Display ( Order = 109 )]
        [QuestionGroup ( "PsychologicalHistory_SignificatnPeriodMuscleTensionHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodMuscleTensionInLifetime { get; set; }

        [Display ( Order = 112 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificatnPeriodMuscleTensionHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodMuscleTensionRelatedToSubstanceUse { get; set; }

        [Display ( Order = 115 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodNegativeThoughtsInLast24Hours { get; set; }

        [Display ( Order = 114 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodNegativeThoughtsInLastMonth { get; set; }

        [Display ( Order = 113 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodNegativeThoughtsHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodNegativeThoughtsInLifetime { get; set; }

        [Display ( Order = 116 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodNegativeThoughtsHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodNegativeThoughtsRelatedToSubstanceUse { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodOfSeriousDepressionInLast24Hours { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.GeneralQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodOfSeriousDepressionInLastMonth { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodExperiencedHeaderNoDrugAlcohol", 0 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodOfSeriousDepressionHeader", 1 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodOfSeriousDepressionInLifetime { get; set; }

        [Display ( Order = 123 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodParanoiaInLast24Hours { get; set; }

        [Display ( Order = 122 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodParanoiaInLastMonth { get; set; }

        [Display ( Order = 121 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodParanoiaHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodParanoiaInLifetime { get; set; }

        [Display ( Order = 124 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodParanoiaHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodParanoiaRelatedToSubstanceUse { get; set; }

        [Display ( Order = 103 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodSleepDisorderInLast24Hours { get; set; }

        [Display ( Order = 102 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodSleepDisorderInLastMonth { get; set; }

        [Display ( Order = 101 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodSleepDisorderHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodSleepDisorderInLifetime { get; set; }

        [Display ( Order = 104 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodSleepDisorderHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodSleepDisorderRelatedToSubstanceUse { get; set; }

        [Display ( Order = 159 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodSuicidalThoughtsInLast24Hours { get; set; }

        [Display ( Order = 158 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodSuicidalThoughtsInLastMonth { get; set; }

        [Display ( Order = 157 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodSuicidalThoughtsHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodSuicidalThoughtsInLifetime { get; set; }

        [Display ( Order = 160 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodSuicidalThoughtsHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodSuicidalThoughtsRelatedToSubstanceUse { get; set; }

        [Display ( Order = 163 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodThoughtsOfSelfInjuryInLast24Hours { get; set; }

        [Display ( Order = 162 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodThoughtsOfSelfInjuryInLastMonth { get; set; }

        [Display ( Order = 161 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodThoughtsOfSelfInjuryHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodThoughtsOfSelfInjuryInLifetime { get; set; }

        [Display ( Order = 164 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodThoughtsOfSelfInjuryHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodThoughtsOfSelfInjuryRelatedToSubstanceUse { get; set; }

        [Display ( Order = 155 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours { get; set; }

        [Display ( Order = 154 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonth { get; set; }

        [Display ( Order = 153 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodTroubleWithAttitudeTowardOthersHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodTroubleWithAttitudeTowardOthersInLifetime { get; set; }

        [Display ( Order = 156 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodTroubleWithAttitudeTowardOthersHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodTroubleWithAttitudeTowardOthersRelatedToSubstanceUse { get; set; }

        [Display ( Order = 127 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodUntruePerceptionInLast24Hours { get; set; }

        [Display ( Order = 126 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodUntruePerceptionInLastMonth { get; set; }

        [Display ( Order = 125 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodUntruePerceptionHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodUntruePerceptionInLifetime { get; set; }

        [Display ( Order = 128 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodUntruePerceptionHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodUntruePerceptionRelatedToSubstanceUse { get; set; }

        [Display ( Order = 151 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodViolentUrgesInLast24Hours { get; set; }

        [Display ( Order = 150 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodViolentUrgesInLastMonth { get; set; }

        [Display ( Order = 149 )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodViolentUrgesHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto SignificantPeriodViolentUrgesInLifetime { get; set; }

        [Display ( Order = 152 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_SignificantPeriodViolentUrgesHeader" )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto SignificantPeriodViolentUrgesRelatedToSubstanceUse { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "PsychologicalHistory_TimesTreatedHeader" )]
        public uint? TimesTreatedForPsychologicalOrEmotionalProblemsAsOutpatient { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.GeneralQuestion )]
        [QuestionGroup ( "PsychologicalHistory_TimesTreatedHeader" )]
        public uint? TimesTreatedForPsychologicalOrEmotionalProblemsInHospital { get; set; }

        [Display ( Order = 43 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto WorriedAboutAnxietyAttackInLast24Hours { get; set; }

        [Display ( Order = 42 )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto WorriedAboutAnxietyAttackInLastMonth { get; set; }

        [Display ( Order = 41 )]
        [QuestionGroup ( "PsychologicalHistory_WorriedAboutAnxietyAttackHeader" )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto WorriedAboutAnxietyAttackInLifetime { get; set; }

        [Display ( Order = 44 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "PsychologicalHistory_WorriedAboutAnxietyAttackHeader", 0 )]
        [QuestionGroup ( "PsychologicalHistory_RegardingAnxietyAttackHeader", 1 )]
        [LookupCategory ( "RelationToSubstanceUse" )]
        public LookupDto WorriedAboutAnxietyAttackRelatedToSubstanceUse { get; set; }

        #endregion
    }
}