namespace Asam.Ppc.Service.Messages.Organization
{
    using System;
    using Agatha.Common;

    public class UpdateStaffRequest:Request
    {
        public enum StaffUpdateType
        {
            Name,
            Email,
            Location,
            NPI
        }

        public long StaffKey { get; set; }
        public StaffUpdateType UpdateType { get; set; }
        public object Value { get; set; }
    }
}