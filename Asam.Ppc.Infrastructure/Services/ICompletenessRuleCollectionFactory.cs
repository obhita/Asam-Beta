namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     Interface for completeness rule collection factory
    /// </summary>
    public interface ICompletenessRuleCollectionFactory
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Gets the completeness rule collection.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <returns></returns>
        ICompletenessRuleCollection<TEntity> GetCompletenessRuleCollection<TEntity> ( string completenessCategory );

        /// <summary>
        ///     Gets the completness rule collections.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IEnumerable<ICompletenessRuleCollection<TEntity>> GetCompletnessRuleCollections<TEntity> ();

        #endregion
    }
}