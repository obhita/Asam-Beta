using System;

namespace Asam.Ppc.Service.Messages.Security
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class ApiSystemAccountDto : KeyedDataTransferObject
    {
        public string Identifier { get; set; }

        [Required]
        public int EhrId { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime? EulaAgreeDate { get; set; }
    }
}