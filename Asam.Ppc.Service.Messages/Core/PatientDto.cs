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
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public LookupDto Gender { get; set; }

        public LookupDto Ethnicity { get; set; }

        public LookupDto Religion { get; set; }

        public long OrganizationKey { get; set; }
    }
}
