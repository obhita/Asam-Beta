namespace Asam.Ppc.Service.Messages.Assessment.Completion
{
    #region Using Statements

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class CompletionSectionDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 7 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "CareLevel" )]
        [CheckAll]
        public IEnumerable<LookupDto> AcceptableLevelsOfCare { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? DetoxificationRequiredMoreThanHourlyMonitoring { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotApplicable" )]
        public LookupDto IsAbleToSelfAdministerMedication { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsCurrentlyResidingInCareLevel_III_1 { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MedicalConditionEndangeredByContinuedSubstanceUse { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MedicalConditionExacerbatedByContinuedSubstanceUse { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto MedicalConditionMakesAbstinenceVital { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotApplicableNotSure" )]
        public LookupDto MedicalConditionStabilizedInPast24HoursPermittingTreatment { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? MedicalProblemsCausedBySubstanceUse { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? PrnHourlyMonitoringSufficientToDetermineDetoxServiceLevel { get; set; }

        [Display ( Order = 19 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "CareLevelSubCategory" )]
        public LookupDto RecommendedCareLevelSubCategory { get; set; }

        [Display ( Order = 18 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory("CareLevel")]
        [CheckAll]
        public IEnumerable<LookupDto> RecommendedCareLevels { get; set; }

        [Display ( Order = 17 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? RequiresTreatmentModeOnlyAvailableInCareLevel_III_7 { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? RespondedPositivelyToEmotionalSupportDuringInterview { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto SymptomsLifeThreateningBecauseOfSubstanceUse { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? SymptomsStabalizedDuringTreatmentDay { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "WithdrawalManagementCareResponseTiming" )]
        public LookupDto TimingOfPositiveResponseToWithdrawalManagementCare { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory("CareLevel")]
        [CheckAll]
        public IEnumerable<LookupDto> UnacceptableCareLevels { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory("CareLevel")]
        [CheckAll]
        public IEnumerable<LookupDto> UnavailableCareLevels { get; set; }

        [Display ( Order = 20 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public LookupDto WouldRecommendProgramToFriend { get; set; }

        [Display(Order = 21)]
        public string ClinicalSummaryNotes { get; set; }

        #endregion
    }
}