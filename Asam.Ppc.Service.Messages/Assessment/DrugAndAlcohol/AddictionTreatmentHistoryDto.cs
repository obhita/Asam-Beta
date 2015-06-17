namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class AddictionTreatmentHistoryDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "CareLevel" )]
        public LookupDto HighestCareLevelFailedFromInPast90Days { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "CareLevel" )]
        public LookupDto MostRecentCareLevelCompleted { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfDaysOutpatientTreatmentInPast30Days { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfTimesAlcoholTreatmentDetoxificationOnlyLifetime { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfTimesDrugTreatmentDetoxificationOnlyLifetime { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfTimesDrugTreatmentLifetime { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public uint? NumberOfTimesTreatedForAlcoholAbuseLifetime { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "SubstanceTreatmentType" )]
        public LookupDto PreviousSubstanceUseTreatment { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? UsuallyEnteredContinuedTreatmentAfterDetoxification { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? UsuallyLeftDetoxificationBeforeAdvised { get; set; }

        #endregion
    }
}