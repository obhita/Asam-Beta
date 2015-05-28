namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    #endregion

    /// <summary>
    /// Contract resolver that ignores serialize attributes and type converters.
    /// </summary>
    public class SerializableContractResolver : DefaultContractResolver
    {
        #region Methods

        protected override JsonContract CreateContract ( Type objectType )
        {
            var contract = base.CreateContract ( objectType );

            if ( contract is JsonStringContract )
            {
                return CreateObjectContract ( objectType );
            }
            return contract;
        }

        protected override IList<JsonProperty> CreateProperties ( Type type, MemberSerialization memberSerialization )
        {
            var properties = base.CreateProperties ( type, memberSerialization );

            foreach ( var p in properties )
            {
                p.Ignored = false;
            }

            return properties;
        }

        #endregion
    }
}