using System.Runtime.Serialization;

namespace Asam.Ppc.Primitives
{
    [DataContract]
    public class ScaleOf0To11 : Scale
    {
        protected ScaleOf0To11()
        {
        }

        public ScaleOf0To11(uint value)
            : base(value, 0, 11)
        {
        }
    }
}
