namespace Asam.Ppc.Service.Messages.Security
{
    using System;
    using Agatha.Common;

    public class ChangePasswordRequest: Request
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}