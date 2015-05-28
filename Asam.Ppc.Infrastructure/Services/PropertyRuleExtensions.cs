namespace Asam.Ppc.Infrastructure.Services
{
    using System;
    using System.Linq.Expressions;
    using Pillar.Common.Utility;
    using Pillar.FluentRuleEngine;

    /// <summary>
    /// Property Rule Extensions
    /// </summary>
    public static class PropertyRuleExtensions
    {
        /// <summary>
        /// Determines whether the <see cref="IPropertyRule"/> property chain contains the property.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="propertyRule">The property rule.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///   <c>true</c> if contains property part; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsPropertyPart<TEntity>(this IPropertyRule propertyRule, Expression<Func<TEntity, object>> propertyExpression)
        {
            return propertyRule.PropertyChain.Contains(PropertyUtil.ExtractPropertyName(propertyExpression));
        }
    }
}