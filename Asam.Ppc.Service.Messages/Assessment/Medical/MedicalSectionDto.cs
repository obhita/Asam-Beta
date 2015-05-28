namespace Asam.Ppc.Service.Messages.Assessment.Medical
{
    #region Using Statements

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class MedicalSectionDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 21 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto AuditoryDisturbanceLevel { get; set; }

        [Display ( Order = 46 )]
        [Question ( QuestionType.GeneralQuestion )]
        public BloodPressure BloodPressure { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public string ChronicMedicalProblemsThatInterfereWithLifeDescription { get; set; }

        [Display ( Order = 19 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public string DescriptionOfMedicalProblemsInPast30Days { get; set; }

        [Display ( Order = 17 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public string DescriptionOfPhysicalDisabilityPension { get; set; }

        [Display ( Order = 45 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public string DescriptionOfReemergentSymptoms { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto ExperiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatus { get; set; }

        [Display ( Order = 30 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto FeverOf102DegreesOrMoreInPast24Hours { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasChronicMedicalProblemsThatInterfereWithLife { get; set; }

        [Display ( Order = 47 )]
        [Question ( QuestionType.GeneralQuestion )]
        public HeartRate HeartRate { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto HighRiskPregnancyStatus { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotApplicableNotSure" )]
        public LookupDto HivAidsMedicalTreatmentStatus { get; set; }

        [Display ( Order = 40 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ImportanceOfTreatmentForMedicalProblems { get; set; }

        [Display ( Order = 50 )]
        [Question ( QuestionType.GeneralQuestion )]
        public string InterviewerComments { get; set; }

        [Display ( Order = 20 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To7 InterviewerObservationOfPatientAgitationLevel { get; set; }

        [Display ( Order = 23 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "SenseOfAwareness" )]
        public LookupDto InterviewerObservationOfPatientSenseOfAwareness { get; set; }

        [Display ( Order = 43 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To8 InterviewerRatingOfPatientNeedForMedicalTreatment { get; set; }

        [Display ( Order = 48 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientMisrepresentingInformation { get; set; }

        [Display ( Order = 49 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientUnableToUnderstand { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? IsTakingPrescriptionMedicine { get; set; }

        [Display ( Order = 39 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto LevelOfConcernInPast30DaysAboutMedicalProblems { get; set; }

        [Display ( Order = 27 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto LostConsciousnessFromHeadTraumaInPast24Hours { get; set; }

        [Display ( Order = 36 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MayRequireInpatientAcutePancreatitisTreatment { get; set; }

        [Display ( Order = 35 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MayRequireInpatientGastrointestinalBleedingTreatment { get; set; }

        [Display ( Order = 34 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MayRequireInpatientLiverTreatment { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public string MedicalProblemDescription { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MedicalProblemThatWouldComplicateDetoxificationStatus { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "MedicalProblemCategory" )]
        public IEnumerable<LookupDto> MedicalProblems { get; set; }

        [Display ( Order = 32 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MobilityProblemsMayAffectTreatmentAttendance { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker MonthsSinceLastHospitalizationForPhysicalProblem { get; set; }

        [Display ( Order = 29 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MultipleSeizuresInPast24Hours { get; set; }

        [Display ( Order = 38 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MultipleSeriousMedicalProblemsExist { get; set; }

        [Display ( Order = 41 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "TreatmentNeedLevel" )]
        public LookupDto NeedForMedicalOrPhysicalRehabilitation { get; set; }

        [Display ( Order = 18 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysWithMedicalProblemsInPast30Days { get; set; }

        [Display ( Order = 42 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto PhysicalHealthsEffectOnSubstanceProblems { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto PregnantStatus { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public string PrescriptionMedicineDescription { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? ReceivesPensionForPhysicalDisability { get; set; }

        [Display ( Order = 33 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto RequiresInpatientCardiacMonitoring { get; set; }

        [Display ( Order = 44 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? RequiresMedicalMonitoringForReemergenceOfSymptoms { get; set; }

        [Display ( Order = 28 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SeizureInPast24Hours { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SexuallyTransmittedDiseaseStatus { get; set; }

        [Display ( Order = 24 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SignsOfIntoxicationExist { get; set; }

        [Display ( Order = 25 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SignsOfToxicPsychosisExist { get; set; }

        [Display ( Order = 26 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SufferedHeadTraumaInPast48Hours { get; set; }

        [Display ( Order = 37 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SufferedSeriousImpairmentFromOverdoseInPast24Hours { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? TimesHospitalizedForMedicalProblems { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto TuberculosisInfectionStatus { get; set; }

        [Display ( Order = 31 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto UnsteadinessOrLossOfBalance { get; set; }

        [Display ( Order = 22 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto VisualDisturbanceLevel { get; set; }

        #endregion
    }
}