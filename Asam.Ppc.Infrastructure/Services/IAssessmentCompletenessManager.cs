namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System;
    using System.Linq.Expressions;
    using Pillar.Common.Metadata.Dtos;

    #endregion

    /// <summary>
    ///     Interface for assessment completeness manager.
    /// </summary>
    public interface IAssessmentCompletenessManager
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Executes the completeness.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="assessment">The assessment.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns></returns>
        CompletenessResults ExecuteCompleteness<TAssessment, TProperty> ( string completenessCategory,
                                                                          TAssessment assessment,
                                                                          Expression<Func<TAssessment, TProperty>> propertyExpression );

        /// <summary>
        ///     Executes the completeness.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="assessment">The assessment.</param>
        /// <returns></returns>
        CompletenessResults ExecuteCompleteness<TAssessment> ( string completenessCategory, TAssessment assessment );

        /// <summary>
        ///     Executes the completeness.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="assessment">The assessment.</param>
        /// <param name="resultSet">The result set.</param>
        /// <returns></returns>
        CompletenessResults ExecuteCompleteness<TAssessment> ( string completenessCategory, TAssessment assessment, string resultSet );

        /// <summary>
        ///     Gets the asssessment completeness metadata.
        /// </summary>
        /// <typeparam name="TAssessment">The type of the assessment.</typeparam>
        /// <returns></returns>
        MetadataDto GetAsssessmentCompletenessMetadata<TAssessment> ();

        #endregion
    }
}