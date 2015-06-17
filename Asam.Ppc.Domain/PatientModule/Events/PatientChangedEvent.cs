using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.PatientModule.Events
{
    public class PatientChangedEvent : IDomainEvent
    {
        public Patient Patient { get; set; }
    }
}