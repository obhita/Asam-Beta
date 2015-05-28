namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using Pillar.Common.Metadata;
    using Pillar.Common.Metadata.Dtos;

    #endregion

    /// <summary>
    ///     Metadata Item dto for completeness
    /// </summary>
    public class RequiredForCompletenessMetadataItemDto : IMetadataItemDto, IMetadataItem
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RequiredForCompletenessMetadataItemDto" /> class.
        /// </summary>
        /// <param name="completenessCategory">The completeness category.</param>
        public RequiredForCompletenessMetadataItemDto ( string completenessCategory )
        {
            CompletenessCategory = completenessCategory;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the completeness category.
        /// </summary>
        /// <value>
        ///     The completeness category.
        /// </value>
        public string CompletenessCategory { get; private set; }

        #endregion
    }
}