using System.Runtime.Serialization;
using Pillar.Domain;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Primitives
{
    [Component]
    [DataContract]
    public class HeartRate : IPrimitive
    {
        protected HeartRate ()
        {
        }

        public HeartRate(uint beatsPerMinute )
        {
            BeatsPerMinute = beatsPerMinute;
        }

        /// <summary>
        /// Gets the beats per minute.
        /// </summary>
        /// <value>The beats per minute.</value>
        [DataMember]
        public virtual uint BeatsPerMinute { get; private set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="HeartRate" /> to <see cref="System.UInt32" />.
        /// </summary>
        /// <param name="heartRate">The heart rate.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator uint (HeartRate heartRate)
        {
            return heartRate.BeatsPerMinute;
        }
    }
}