namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class DrugConsequencesDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 1 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public MoneyDto AmountOfMoneySpentOnDrugsInPast30Days { get; set; }

        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto ImportanceOfTreatmentForSubstanceProblem { get; set; }

        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [Range ( 0, 30 )]
        public uint? NumberOfDaysExperiencedSubstanceProblemsInPast30Days { get; set; }

        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "LikertScale" )]
        public LookupDto TroubledInLast30DaysBySubstanceProblems { get; set; }

        #endregion
    }
}