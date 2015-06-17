using System;
using System.ComponentModel.DataAnnotations;
using Asam.Ppc.Primitives;
using Asam.Ppc.Service.Messages.Common;
using Asam.Ppc.Service.Messages.Common.Lookups;

namespace Asam.Ppc.Service.Messages.Core
{
    public class PatientDto : KeyedDataTransferObject
    {
        [Required]
        public PersonName Name { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [RegularExpression(@"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d", ErrorMessage = "Date must be in the format MM/DD/YYYY.")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public LookupDto Gender { get; set; }

        public LookupDto Ethnicity { get; set; }

        public LookupDto Religion { get; set; }
    }
}
