using System;
using Pillar.Domain;

namespace Asam.Ppc.Domain.CommonModule
{
    public abstract class AggregateRootBase : Entity, IAggregateRoot, IAuditable
    {
        protected AggregateRootBase()
        {
            CreatedTimestamp = DateTimeOffset.Now;
            UpdatedTimestamp = DateTimeOffset.Now;
        }

        #region IAggregate Members

        public virtual DateTimeOffset CreatedTimestamp { get; set; }

        public virtual string CreatedSystemAccount { get; set; }

        public virtual DateTimeOffset UpdatedTimestamp { get; set; }

        public virtual string UpdatedSystemAccount { get; set; }

        #endregion
    }
}