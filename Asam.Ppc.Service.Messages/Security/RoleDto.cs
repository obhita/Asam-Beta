namespace Asam.Ppc.Service.Messages.Security
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;

    #endregion

    public class RoleDto : KeyedDataTransferObject
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<string> Permissions { get; set; }
    }
}