using System;

namespace Asam.Ppc.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsNullable(this Type type)
        {
            if (!type.IsValueType) 
            {
                return true; // ref-type
            }
            return Nullable.GetUnderlyingType(type) != null;
        }
    }
}
