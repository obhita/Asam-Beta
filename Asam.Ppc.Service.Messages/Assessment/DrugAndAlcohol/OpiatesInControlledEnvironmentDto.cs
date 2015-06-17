namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;

    #endregion

    public class OpiatesInControlledEnvironmentDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? ExperiencesWithdrawalSickness { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "OpiatesInControlledEnvironment_ControlledEnvironmentHeader" )]
        public bool? IncreasedDoseRequiredToGetSameEffect { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [QuestionGroup ( "OpiatesInControlledEnvironment_ControlledEnvironmentHeader" )]
        public bool? TakenNaltrexoneOrNaloxoneDuringWithdrawalInPast48Hours { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? UseSubstanceToPreventWithdrawalSickness { get; set; }

        #endregion
    }
}