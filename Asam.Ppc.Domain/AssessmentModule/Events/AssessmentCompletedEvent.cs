using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.AssessmentModule.Events
{
    public class AssessmentCompletedEvent : IDomainEvent
    {
        public long AssessmentKey { get; set; }
        public string Username { get; set; }
    }
}