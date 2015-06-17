namespace Asam.Ppc.Service.Messages.Assessment
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Common;
    using Pillar.Common.Metadata;
    using Pillar.Common.Metadata.Dtos;

    #endregion

    /// <summary>
    /// Base class for Section Dtos.
    /// </summary>
    public abstract class SectionDtoBase : KeyedDataTransferObject, IAssessmentDto, IMetadataProvider
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the metadata dto.
        /// </summary>
        /// <value>
        /// The metadata dto.
        /// </value>
        [ScaffoldColumn ( false )]
        public MetadataDto MetadataDto { get; set; }

        #endregion
    }
}