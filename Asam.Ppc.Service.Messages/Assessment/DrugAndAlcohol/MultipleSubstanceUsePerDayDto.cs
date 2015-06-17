namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;
    using Primitives;

    #endregion

    public class MultipleSubstanceUsePerDayDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? HasHealthCareProviderPrescribedUse { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeMeasure LastUsed { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysUsedInPast30Days { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsUsedInLifetime { get; set; }

        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "SubstanceTakenAsPrescribed" )]
        public LookupDto WasSubstanceTakenAsPrescribed { get; set; }

        #endregion
    }
}