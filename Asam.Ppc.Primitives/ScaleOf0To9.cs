using System.Runtime.Serialization;

namespace Asam.Ppc.Primitives
{
    [DataContract]
    public class ScaleOf0To9 : Scale
    {
        protected ScaleOf0To9 ()
        {
        }

        public ScaleOf0To9( uint value )
            :base(value, 0, 9)
        {
        }  
    }
}