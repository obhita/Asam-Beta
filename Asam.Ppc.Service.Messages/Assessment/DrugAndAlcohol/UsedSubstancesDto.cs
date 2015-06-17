namespace Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol
{
    #region Using Statements

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common.Lookups;

    #endregion

    public class UsedSubstancesDto : SectionDtoBase
    {
        #region Public Properties

        [Display ( Order = 1 )]
        [LookupCategory ( "SubstanceCategory" )]
        [QuestionGroup ( "UsedSubstances_SubstanceHasEverUsed", "TwelveColumns" )]
        public IEnumerable<LookupDto> SubstanceHasEverUsed { get; set; }

        #endregion
    }
}