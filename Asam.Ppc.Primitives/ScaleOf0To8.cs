using System.Runtime.Serialization;

namespace Asam.Ppc.Primitives
{
    [DataContract]
    public class ScaleOf0To8 : Scale
    {
        protected ScaleOf0To8 ()
        {
        }

        public ScaleOf0To8( uint value )
            :base(value, 0, 8)
        {
        }  
    }
}