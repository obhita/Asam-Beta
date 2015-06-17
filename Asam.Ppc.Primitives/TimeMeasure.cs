using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Pillar.Domain;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Primitives
{
    [Component]
    [DataContract]
    public class TimeMeasure : IPrimitive
    {
        protected TimeMeasure ()
        {
        }

        public TimeMeasure(UnitOfTime unitOfTime, uint value)
        {
            UnitOfTime = unitOfTime;
            Value = value;
        }

        [UIHint("Enum")]
        [DataMember]
        public UnitOfTime UnitOfTime { get; private set; }

        [DataMember]
        public uint Value { get; private set; }
    }
}
