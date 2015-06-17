namespace Asam.Ppc.Service.Messages.Assessment.Psychological
{
    #region Using Statements

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class InterviewerRatingDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 20 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "PsychiatricDiagnosis" )]
        public IEnumerable<LookupDto> ActivePsychiatricDiagnosesOtherThanSubstanceAbuse { get; set; }

        [Display ( Order = 28 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto AddictionOnlyTreatmentAccessibleToPatient { get; set; }

        [Display ( Order = 4 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader", "ThreeColumns" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalScaleLegend )]
        public ScaleOf0To8 AppearanceOfAnxietyNervousness { get; set; }

        [Display ( Order = 1 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader", "ThreeColumns" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalScaleLegend )]
        public ScaleOf0To8 AppearanceOfDepressionWithdrawal { get; set; }

        [Display ( Order = 8 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 AppearanceOfFluctuatingOrientationInLast24Hours { get; set; }

        [Display ( Order = 2 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 AppearanceOfHostility { get; set; }

        [Display ( Order = 7 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader", "ThreeColumns" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalScaleLegend )]
        public ScaleOf0To8 AppearanceOfLethargy { get; set; }

        [Display ( Order = 5 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 AppearanceOfParanoiaOrImpairedThinking { get; set; }

        [Display ( Order = 9 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 AppearanceOfSpeechImpairmentBadPosture { get; set; }

        [Display ( Order = 6 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 AppearanceOfTroubleConcentratingOrRemembering { get; set; }

        [Display ( Order = 3 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 AppearanceofAgitation { get; set; }

        [Display ( Order = 23 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto CurrentBehaviorInconsistentWithSelfCare { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto CurrentProblemBehaviorsRequireContinuousInterventions { get; set; }

        [Display ( Order = 11 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 DemonstratingDangerToSelfOrOthers { get; set; }

        [Display ( Order = 19 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "PatientCarriesPsychiatricDiagnosis" )]
        public LookupDto DoesPatientCarryPsychiatricDiagnosis { get; set; }

        [Display ( Order = 21 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto EvidenceOfChronicOrganicMentalDisability { get; set; }

        [Display ( Order = 31 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [QuestionGroup ( "InterviewerRating_GlobalAssessmentOfFunctioningHeader" )]
        [QuestionGroup ( "InterviewerRating_GlobalAssessmentOfFunctioningHeader" )]
        public uint? GlobalAssessmentOfFunctioningScore { get; set; }

        [Display ( Order = 10 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader", "ThreeColumns" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalScaleLegend )]
        public ScaleOf0To8 HasSuicidalThoughts { get; set; }

        [Display ( Order = 12 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader", "ThreeColumns" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 IndicatingRiskOfHarmToOthers { get; set; }

        [Display ( Order = 13 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader", "ThreeColumns" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalScaleLegend )]
        public ScaleOf0To8 IndicatingRiskOfHarmToSelfOrVictimizationByOthers { get; set; }

        [Display ( Order = 27 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto IntensiveCaseManagementAccessibleToPatient { get; set; }

        [Display ( Order = 31 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public string InterviewerComments { get; set; }

        [Display ( Order = 29 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto IsPatientMisrepresentingInformation { get; set; }

        [Display ( Order = 30 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto IsPatientUnableToUnderstand { get; set; }

        [Display ( Order = 17 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To8 LevelOfSupervisionNeededForProtectionFromSelfHarm { get; set; }

        [Display ( Order = 16 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To8 LikelihoodOfRecurrenceOfPsychiatricDecompensation { get; set; }

        [Display ( Order = 14 )]
        [QuestionGroup ( "InterviewerRating_AppearanceOfHeader" )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.VerticalQuestion )]
        public ScaleOf0To8 LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers { get; set; }

        [Display ( Order = 18 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? PatientAbleToSafelyAccessNeededResources { get; set; }

        [Display ( Order = 22 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To8 PatientNeedForPsychiatricPsychologicalTreatmentRating { get; set; }

        [Display ( Order = 25 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto PatientRequires24HourControlledSupervisedEnvironment { get; set; }

        [Display ( Order = 26 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto PsychiatricEvaluationAndServicesAccessibleToPatient { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse" )]
        public LookupDto RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse { get; set; }

        #endregion
    }
}