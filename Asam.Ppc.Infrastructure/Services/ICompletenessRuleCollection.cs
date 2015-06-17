namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using Pillar.FluentRuleEngine;

    #endregion

    /// <summary>
    ///     Completeness Rule Collection Interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ICompletenessRuleCollection<TEntity> : IRuleCollection<TEntity>
    {
        #region Public Properties

        /// <summary>
        ///     Gets the completeness category.
        /// </summary>
        /// <value>
        ///     The completeness category.
        /// </value>
        string CompletenessCategory { get; }

        #endregion
    }
}