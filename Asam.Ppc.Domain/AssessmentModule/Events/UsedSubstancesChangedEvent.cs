#region Using Statements

using System.Collections.Generic;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol;
using Pillar.Domain.Event;

#endregion

namespace Asam.Ppc.Domain.AssessmentModule.Events
{
    /// <summary>
    /// Class for used substance change event.
    /// </summary>
    public class UsedSubstancesChangedEvent : IDomainEvent
    {
        public UsedSubstancesChangedEvent(long assessmentId)
        {
            AssessmentId = assessmentId;
        }

        /// <summary>
        /// Gets or sets the assessment id.
        /// </summary>
        /// <value>
        /// The assessment id.
        /// </value>
        public long AssessmentId { get; protected set; }

        /// <summary>
        /// Gets or sets the new values.
        /// </summary>
        /// <value>
        /// The new values.
        /// </value>
        public IEnumerable<SubstanceCategory> NewValues { get; set; }

        /// <summary>
        /// Gets or sets the old values.
        /// </summary>
        /// <value>
        /// The old values.
        /// </value>
        public IEnumerable<SubstanceCategory> OldValues { get; set; }
    }
}