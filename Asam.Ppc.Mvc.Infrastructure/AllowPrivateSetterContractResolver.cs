using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Asam.Ppc.Mvc.Infrastructure
{
    public class AllowPrivateSetterContractResolver : DefaultContractResolver
    {
        // more @ http://daniel.wertheim.se/2010/11/06/json-net-private-setters/
        protected override JsonProperty CreateProperty ( MemberInfo member, MemberSerialization memberSerialization )
        {
            var prop = base.CreateProperty ( member, memberSerialization );

            if ( !prop.Writable )
            {
                var property = member as PropertyInfo;

                if ( property != null )
                {
                    var hasPrivateSetter = property.GetSetMethod ( true ) != null;

                    prop.Writable = hasPrivateSetter;
                }
            }

            return prop;
        }
    }
}
