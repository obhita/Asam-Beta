using System.Runtime.Serialization;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Primitives
{
    [Component]
    [DataContract]
    public class BloodPressure : IPrimitive
    {
        protected BloodPressure ()
        {
        }

        public BloodPressure( uint systolic, uint diastolic )
        {
            Systolic = systolic;
            Diastolic = diastolic;
        }

        [DataMember]
        public virtual uint Systolic { get; private set; }

        [DataMember]
        public virtual uint Diastolic { get; private set; }
    }
}