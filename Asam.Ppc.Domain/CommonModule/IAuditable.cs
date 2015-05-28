using System;

namespace Asam.Ppc.Domain.CommonModule
{
    public interface IAuditable
    {
        DateTimeOffset CreatedTimestamp { get; set; }

        string CreatedSystemAccount { get; set; }

        DateTimeOffset UpdatedTimestamp { get; set; }

        string UpdatedSystemAccount { get; set; }
    }
}