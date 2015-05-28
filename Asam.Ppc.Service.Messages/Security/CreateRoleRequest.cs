namespace Asam.Ppc.Service.Messages.Security
{
    #region

    using System;
    using Agatha.Common;

    #endregion

    public class CreateRoleRequest : Request
    {
        public string  Name { get; set; }
    }
}