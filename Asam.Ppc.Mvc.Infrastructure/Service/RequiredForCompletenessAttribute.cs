namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    #region Using Statements

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// Attribute to specify completeness.
    /// </summary>
    public class RequiredForCompletenessAttribute : ValidationAttribute, IClientValidatable
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredForCompletenessAttribute" /> class.
        /// </summary>
        /// <param name="completenessCategory">The completeness category.</param>
        public RequiredForCompletenessAttribute ( string completenessCategory )
        {
            CompletenessCategory = completenessCategory;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the completeness category.
        /// </summary>
        /// <value>
        /// The completeness category.
        /// </value>
        public string CompletenessCategory { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// When implemented in a class, returns client validation rules for that class.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        /// <param name="context">The controller context.</param>
        /// <returns>
        /// The client validation rules for this validator.
        /// </returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules ( ModelMetadata metadata, ControllerContext context )
        {
            var rule = new ModelClientValidationRule {ValidationType = "completeness"};
            rule.ValidationParameters.Add ( new KeyValuePair<string, object> ( CompletenessCategory, null ) );
            return new List<ModelClientValidationRule> {rule};
        }

        #endregion
    }
}