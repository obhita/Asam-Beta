using System.Runtime.Serialization;

namespace Asam.Ppc.Primitives
{
    [DataContract]
    public class ScaleOf0To7 : Scale
    {
        protected ScaleOf0To7 ()
        {
        }

        public ScaleOf0To7( uint value )
            :base(value, 0, 7)
        {
        }  
    }
}