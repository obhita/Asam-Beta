using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.AssessmentModule.Events
{
    public class SectionVisitedEvent : IDomainEvent
    {
        public long AssessmentId { get; set; }
    }
}