namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Pillar.Common.Metadata.Dtos;
    using Pillar.Common.Utility;
    using Pillar.FluentRuleEngine;

    #endregion

    /// <summary>
    ///     Manager for handling assessment Completeness
    /// </summary>
    public class AssessmentCompletenessManager : IAssessmentCompletenessManager
    {
        #region Fields

        private readonly IDictionary<Type, MetadataDto> _assessmentMetadataDtoCache = new Dictionary<Type, MetadataDto> ();
        private readonly ICompletenessRuleCollectionFactory _completenessRuleCollectionFactory;
        private readonly IRuleEngineFactory _ruleEngineFactory;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AssessmentCompletenessManager" /> class.
        /// </summary>
        /// <param name="completenessRuleCollectionFactory">The completeness rule collection factory.</param>
        /// <param name="ruleEngineFactory">The rule engine factory.</param>
        public AssessmentCompletenessManager ( ICompletenessRuleCollectionFactory completenessRuleCollectionFactory, IRuleEngineFactory ruleEngineFactory )
        {
            _completenessRuleCollectionFactory = completenessRuleCollectionFactory;
            _ruleEngineFactory = ruleEngineFactory;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Executes the completeness.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="assessment">The assessment.</param>
        /// <param name="ruleSet">The rule set.</param>
        /// <returns></returns>
        public CompletenessResults ExecuteCompleteness<TAssessment> ( string completenessCategory, TAssessment assessment, string ruleSet )
        {
            var ruleCollection = _completenessRuleCollectionFactory.GetCompletenessRuleCollection<TAssessment> ( completenessCategory );
            var ruleEngine = _ruleEngineFactory.CreateRuleEngine ( assessment, ruleCollection );
            return ExecuteCompleteness ( ruleEngine, completenessCategory, assessment, ruleSet );
        }

        /// <summary>
        ///     Executes the completeness.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="assessment">The assessment.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns></returns>
        public CompletenessResults ExecuteCompleteness<TAssessment, TProperty> ( string completenessCategory,
                                                                                 TAssessment assessment,
                                                                                 Expression<Func<TAssessment, TProperty>> propertyExpression )
        {
            var ruleCollection = _completenessRuleCollectionFactory.GetCompletenessRuleCollection<TAssessment> ( completenessCategory );
            var ruleEngine = _ruleEngineFactory.CreateRuleEngine ( assessment, ruleCollection );
            return ExecuteCompleteness ( ruleEngine, completenessCategory, assessment, PropertyUtil.ExtractPropertyName ( propertyExpression ) );
        }

        /// <summary>
        ///     Executes the completeness.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="assessment">The assessment.</param>
        /// <returns></returns>
        public CompletenessResults ExecuteCompleteness<TAssessment> ( string completenessCategory, TAssessment assessment )
        {
            var ruleCollection = _completenessRuleCollectionFactory.GetCompletenessRuleCollection<TAssessment> ( completenessCategory );
            var ruleEngine = _ruleEngineFactory.CreateRuleEngine ( assessment, ruleCollection );
            var results = ruleCollection.RuleSets.Select ( rs => rs.Name )
                                        .ToDictionary ( ruleSet => ruleSet.Replace ( "RuleSet", "" ),
                                                        ruleSet => ExecuteCompleteness ( ruleEngine, completenessCategory, assessment, ruleSet ) );
            return new CompletenessResults ( completenessCategory, results.Values.Sum ( c => c.Total ), results.Values.Sum ( c => c.NumberInComplete ) )
                {
                    CompletenessResultsPerRuleSet = results
                };
        }

        /// <summary>
        ///     Gets the asssessment completeness metadata.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <returns></returns>
        public MetadataDto GetAsssessmentCompletenessMetadata<TAssessment> ()
        {
            var assessmentType = typeof(TAssessment);
            MetadataDto metadataDto;
            if ( !_assessmentMetadataDtoCache.ContainsKey ( assessmentType ) )
            {
                metadataDto = CreateMetadataDto<TAssessment> ();
                _assessmentMetadataDtoCache.Add ( assessmentType, metadataDto );
            }
            else
            {
                metadataDto = _assessmentMetadataDtoCache[assessmentType];
            }
            return metadataDto;
        }

        #endregion

        #region Methods

        private MetadataDto CreateMetadataDto<T> ()
        {
            var metadataDto = new MetadataDto ( typeof(T).Name );
            var completenessRuleCollections = _completenessRuleCollectionFactory.GetCompletnessRuleCollections<T> ();
            completenessRuleCollections.ToList ();
            foreach ( var completenessRuleCollection in completenessRuleCollections )
            {
                foreach ( var ruleSet in completenessRuleCollection.RuleSets )
                {
                    var ruleSetMetadataDto = metadataDto;
                    var firstRule = (IPropertyRule) ruleSet.First ( r => r is IPropertyRule && !r.IsDisabled );
                    if ( firstRule == null )
                    {
                        continue;
                    }
                    ruleSetMetadataDto = firstRule.PropertyChain.Take ( firstRule.PropertyChain.Count - 1 )
                                                  .Aggregate ( ruleSetMetadataDto, ( current, propertyPart ) => current.GetChildMetadata ( propertyPart ) );
                    foreach ( IPropertyRule rule in ruleSet.Where ( r => !r.IsDisabled ) )
                    {
                        var childMetadata = ruleSetMetadataDto.AddChildMetadata ( rule.PropertyChain.Last () );
                        childMetadata.AddMetadataItem ( new RequiredForCompletenessMetadataItemDto ( completenessRuleCollection.CompletenessCategory ) );
                    }
                }
            }
            return metadataDto;
        }

        /// <summary>
        ///     Executes the completeness.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <param name="ruleEngine">The rule engine.</param>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="assessment">The assessment.</param>
        /// <param name="ruleSet">The rule set.</param>
        /// <returns></returns>
        private CompletenessResults ExecuteCompleteness<TAssessment> ( IRuleEngine<TAssessment> ruleEngine, string completenessCategory, TAssessment assessment, string ruleSet )
        {
            var results = ruleEngine.ExecuteRuleSet ( assessment, !ruleSet.EndsWith ( "RuleSet" ) ? ruleSet + "RuleSet" : ruleSet );
            return new CompletenessResults ( completenessCategory, results.NumberOfRulesExecuted, results.RuleViolations.Count () );
        }

        #endregion
    }
}