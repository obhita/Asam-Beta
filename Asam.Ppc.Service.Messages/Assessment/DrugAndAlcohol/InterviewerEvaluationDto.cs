namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class InterviewerEvaluationDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 6 )]
        [ReadOnly ( true )]
        [HiddenInput ( DisplayValue = true )]
        public bool? BarbituratesHasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? HasMaintainedBarbituatesDoseAtTherapeuticLevels { get; set; }

        [Display ( Order = 16 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? HasMaintainedMethadoneDoseAtTherapeuticLevels { get; set; }

        [Display ( Order = 14 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? HasMaintainedNicotineDoseAtTherapeuticLevels { get; set; }

        [Display ( Order = 15 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? HasMaintainedOtherDrugDoseAtTherapeuticLevels { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? HasMaintainedOtherOpiatesDoseAtTherapeuticLevels { get; set; }

        [Display ( Order = 12 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? HasMaintainedSedativeDoseAtTherapeuticLevels { get; set; }

        [Display ( Order = 13 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? HasMaintainedStimulantDoseAtTherapeuticLevels { get; set; }

        [Display ( Order = 5 )]
        [ReadOnly ( true )]
        [HiddenInput ( DisplayValue = true )]
        public bool? MethadoneHasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 4 )]
        [ReadOnly ( true )]
        [HiddenInput ( DisplayValue = true )]
        public bool? NicotineHasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 3 )]
        [ReadOnly ( true )]
        [HiddenInput ( DisplayValue = true )]
        public bool? OtherOpiateHasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 2 )]
        [ReadOnly ( true )]
        [HiddenInput ( DisplayValue = true )]
        public bool? OtherSedativesHasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 0 )]
        [ReadOnly ( true )]
        [HiddenInput ( DisplayValue = true )]
        [QuestionGroup ( "InterviewerEvaluation_HiddenQuestions" )]
        public bool? OtherSubstanceHasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 1 )]
        [ReadOnly ( true )]
        [HiddenInput ( DisplayValue = true )]
        public bool? StimulantsHasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 7 )]
        [LookupCategory ( "SubstanceCategory" )]
        [QuestionGroup ( "InterviewerEvaluation_HiddenQuestions" )]
        [ReadOnly ( true )]
        public IEnumerable<LookupDto> SubstanceHasEverUsed { get; set; }

        #endregion
    }
}