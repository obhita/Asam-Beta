using System;
using System.Runtime.Serialization;
using Pillar.Domain;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Primitives
{
    [Component]
    [DataContract]
    public abstract class Scale : IPrimitive
    {
        protected Scale ()
        {
        }

        protected Scale(uint value, uint min, uint max)
        {
            if(value < min || value > max)
            {
                throw new ArgumentException(string.Format ( "{0} must be equal to or between {1} and {2}", value, min, max ), "value");
            }
            Value = value;
            Min = min;
            Max = max;
        }

        [DataMember]
        public virtual uint Value { get; protected set; }

        [DataMember]
        public virtual uint Min { get; protected set; }

        [DataMember]
        public virtual uint Max { get; protected set; }

        public static implicit operator uint(Scale scale)
        {
            return scale == null ? 0 : scale.Value;
        }
    }
}
