namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class CinaScaleDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 1 )]
        [UIHint ( "VerticalScale" )]
        [Question ( QuestionType.SingleVerticalScaleLegend )]
        public ScaleOf0To9 ExperiencedNauseaOrVomitedRecently { get; set; }

        [Display ( Order = 10 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "BodyTemperatureStatus" )]
        public LookupDto FeelsHotOrCold { get; set; }

        [Display ( Order = 9 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "AbdominalPainStatus" )]
        public LookupDto HasAbdominalPain { get; set; }

        [Display ( Order = 11 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "MuscleAcheStatus" )]
        public LookupDto HasMuscleAches { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "GooseFleshObservation" )]
        public LookupDto ObservedGooseFlesh { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "LacriminationObservation" )]
        public LookupDto ObservedLacrimination { get; set; }

        [Display ( Order = 7 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "NasalCongestionObservation" )]
        public LookupDto ObservedNasalCongestion { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "RestlessnessObservation" )]
        public LookupDto ObservedRestlessness { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "SweatingObservation" )]
        public LookupDto ObservedSweating { get; set; }

        [Display ( Order = 5 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "TremorObservation" )]
        public LookupDto ObservedTremor { get; set; }

        [Display ( Order = 8 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "YawningObservation" )]
        public LookupDto ObservedYawning { get; set; }

        #endregion
    }
}