namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System.Collections.Generic;
    using Pillar.Common.InversionOfControl;
    using Pillar.FluentRuleEngine;

    #endregion

    /// <summary>
    ///     Factory for creating completeness rule collections.
    /// </summary>
    public class CompletenessRuleCollectionFactory : ICompletenessRuleCollectionFactory
    {
        #region Fields

        private readonly IContainer _container;
        private readonly IRuleCollectionFactory _ruleCollectionFactory;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CompletenessRuleCollectionFactory" /> class.
        /// </summary>
        /// <param name="ruleCollectionFactory">The rule collection factory.</param>
        /// <param name="container">The container.</param>
        public CompletenessRuleCollectionFactory ( IRuleCollectionFactory ruleCollectionFactory, IContainer container )
        {
            _ruleCollectionFactory = ruleCollectionFactory;
            _container = container;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the completeness rule collection.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <returns></returns>
        public ICompletenessRuleCollection<TEntity> GetCompletenessRuleCollection<TEntity> ( string completenessCategory )
        {
            var completenessRuleCollection = (ICompletenessRuleCollection<TEntity>) _container.TryResolve ( typeof(ICompletenessRuleCollection<TEntity>), completenessCategory );
            _ruleCollectionFactory.CustomizeRuleCollection ( completenessRuleCollection );
            return completenessRuleCollection;
        }

        /// <summary>
        ///     Gets the completness rule collections.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IEnumerable<ICompletenessRuleCollection<TEntity>> GetCompletnessRuleCollections<TEntity> ()
        {
            var completenessRuleCollections = _container.ResolveAll<ICompletenessRuleCollection<TEntity>> ();
            foreach ( var completenessRuleCollection in completenessRuleCollections )
            {
                _ruleCollectionFactory.CustomizeRuleCollection ( completenessRuleCollection );
                yield return completenessRuleCollection;
            }
        }

        #endregion
    }
}