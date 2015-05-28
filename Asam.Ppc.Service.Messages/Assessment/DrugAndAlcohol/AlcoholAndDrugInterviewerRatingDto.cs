namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class AlcoholAndDrugInterviewerRatingDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 11 )]
        [Question ( QuestionType.GeneralQuestion )]
        public string InterviewerComments { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [UIHint ( "HighLowScale" )]
        public ScaleOf0To9 InterviewerScoreOfAlcoholTreatmentNeed { get; set; }

        [Display ( Order = 1 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To9 InterviewerScoreOfAttitude { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [UIHint ( "HighLowScale" )]
        public ScaleOf0To9 InterviewerScoreOfDrugTreatmentNeed { get; set; }

        [Display ( Order = 2 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To9 InterviewerScoreOfReadiness { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "SignsOfWithdrawal" )]
        public LookupDto IsPatientExperiencingWithdrawalSignsSymptoms { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientMisrepresentingInformation { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? IsPatientUnableToUnderstand { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? MajorityOfInformationFromCollateralSource { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public string PatientManifestingSeriousRelapseBehaviorDescription { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? PatientManifestingSeriousRelapseBehaviors { get; set; }

        #endregion
    }
}