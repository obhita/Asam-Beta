namespace Asam.Ppc.Domain.AssessmentModule
{
    #region Using Statements

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Pillar.Domain;

    #endregion

    /// <summary>
    ///     Revision class.
    /// </summary>
    public abstract class RevisionBase : Entity
    {
        #region Fields

        /// <summary>
        ///     The _property cache
        /// </summary>
        private Dictionary<string, PropertyInfo> _propertyCache;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visited.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is visited; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsVisited { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Revises the property.
        /// </summary>
        /// <param name="assessmentId">The assessment id.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        /// <exception cref="System.InvalidCastException"></exception>
        public virtual void ReviseProperty ( long assessmentId, string propertyName, object value )
        {
            if ( _propertyCache == null )
            {
                _propertyCache =
                    GetType ()
                        .GetProperties ( BindingFlags.Public | BindingFlags.Instance |
                                         BindingFlags.FlattenHierarchy )
                        .ToDictionary ( pi => pi.Name );
            }
            PropertyInfo property = _propertyCache.ContainsKey ( propertyName ) ? _propertyCache[propertyName] : null;
            if ( property == null )
            {
                throw new ArgumentException ( string.Format ( "Invalid property name {0}", propertyName ), "propertyName" );
            }

            //TODO: Run rules based on property name

            if ( value != null )
            {
                Type valueType = value.GetType ();
                if ( property.PropertyType.IsGenericType &&
                     ( property.PropertyType.GetGenericTypeDefinition () == typeof(IEnumerable<>) ||
                       property.PropertyType.GetGenericTypeDefinition () == typeof(IList<>) ) )
                {
                    if ( IsAssignableToGenericType ( valueType, typeof(IEnumerable<>) ) )
                    {
                        Type propertyArgumentType = property.PropertyType.GetGenericArguments ()[0];
                        Type valueArgumentType = valueType.GetGenericArguments ()[0];
                        if ( !propertyArgumentType.IsAssignableFrom ( valueArgumentType ) )
                        {
                            Type convertToType = GetConvertToType ( property.PropertyType );
                            var newValues =
                                Activator.CreateInstance ( typeof(List<>).MakeGenericType ( propertyArgumentType ) ) as IList;

                            foreach ( var oldValue in ( value as IEnumerable ) )
                            {
                                newValues.Add ( Convert.ChangeType ( oldValue, convertToType ) );
                            }
                            value = newValues;
                        }
                    }
                    else
                    {
                        throw new InvalidCastException ( string.Format ( "Cannot convert type {0} to type {1}.",
                                                                         valueType,
                                                                         property.PropertyType ) );
                    }
                }
                else if ( !property.PropertyType.IsAssignableFrom ( valueType ) )
                {
                    Type convertToType = GetConvertToType ( property.PropertyType );
                    value = Convert.ChangeType ( value, convertToType );
                }
            }

            property.SetValue ( this, value );
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Determines whether [is assignable to generic type] [the specified given type].
        /// </summary>
        /// <param name="givenType">Type of the given.</param>
        /// <param name="genericType">Type of the generic.</param>
        /// <returns>
        ///     <c>true</c> if [is assignable to generic type] [the specified given type]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsAssignableToGenericType ( Type givenType, Type genericType )
        {
            Type[] interfaceTypes = givenType.GetInterfaces ();

            foreach ( var it in interfaceTypes )
            {
                if ( it.IsGenericType )
                {
                    if ( it.GetGenericTypeDefinition () == genericType )
                    {
                        return true;
                    }
                }
            }

            Type baseType = givenType.BaseType;
            if ( baseType == null )
            {
                return false;
            }

            return baseType.IsGenericType &&
                   baseType.GetGenericTypeDefinition () == genericType ||
                   IsAssignableToGenericType ( baseType, genericType );
        }

        /// <summary>
        ///     Gets the type of the convert to.
        /// </summary>
        /// <param name="propertyType">Type of the property.</param>
        /// <returns></returns>
        private Type GetConvertToType ( Type propertyType )
        {
            Type convertToType = propertyType;
            Type underlyingType = Nullable.GetUnderlyingType ( convertToType );
            if ( underlyingType != null )
            {
                convertToType = underlyingType;
            }
            return convertToType;
        }

        #endregion
    }
}