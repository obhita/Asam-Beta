namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class OpioidMaintenanceTherapyDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 3 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? CompletedAtLeast6MonthOpioidMaintenanceTherapyVoluntarily { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? DetoxificationEndedLessThanOrEqual2YearsAgo { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? GraduallyDetoxedFromOpioidMaintenanceTherapy { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? OpioidMaintenanceTherapyReadmissionMedicallyIndicated { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public string PhysicianReasonsForOpioidMaintenanceTherapyReadmission { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "OpioidDetoxificationProtocol" )]
        public LookupDto ToBePrescribedOpioidDetoxificationProtocol { get; set; }

        #endregion
    }
}