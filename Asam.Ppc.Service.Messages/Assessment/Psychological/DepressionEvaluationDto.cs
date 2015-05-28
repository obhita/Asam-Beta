namespace Asam.Ppc.Service.Messages.Assessment.Psychological
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class DepressionEvaluationDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 6 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "RetardationOfThoughtOrSpeech" )]
        public LookupDto ObservedRetardationOfThoughtOrSpeech { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RangeOfEnergy" )]
        public LookupDto RangeOfEnergyInPastWeek { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RangeOfGuilt" )]
        public LookupDto RangeOfGuiltInPastWeek { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RangeOfInterestInDoingThings" )]
        public LookupDto RangeOfInterestInDoingThingsInPastWeek { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RangeOfIrritability" )]
        public LookupDto RangeOfIrritabilityInPastWeek { get; set; }

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "RangeOfMood" )]
        public LookupDto RangeOfMoodInPastWeek { get; set; }

        #endregion
    }
}