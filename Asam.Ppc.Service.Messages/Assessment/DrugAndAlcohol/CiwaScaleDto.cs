namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class CiwaScaleDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "ExperiencedNauseaOrVomitedRecently" )]
        public LookupDto ExperiencedNauseaOrVomitedRecently { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YesNoNotSure" )]
        public LookupDto HadDeliriumTremorsInPast24Hours { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "HeadAcheOrFullnessSeverity" )]
        public LookupDto HeadAcheOrFullnessSeverity { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "NervousnessObservation" )]
        public LookupDto ObservedNervousness { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "SweatingObservation" )]
        public LookupDto ObservedSweating { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "TactileDisturbancesObservation" )]
        public LookupDto ObservedTactileDisturbances { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "TremorObservation" )]
        public LookupDto ObservedTremor { get; set; }

        #endregion
    }
}