namespace Asam.Ppc.Service.Messages.Common
{
    using Infrastructure.Services;

    /// <summary>
    /// Get Section Dto Response
    /// </summary>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    public class GetSectionDtoByKeyResponse<TDto> : GetDtoByKeyResponse<TDto>
        where TDto : IKeyedDataTransferObject
    {
        #region Public Properties

        public CompletenessResults Completeness { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is submitted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is submitted; otherwise, <c>false</c>.
        /// </value>
        public bool IsSubmitted { get; set; }

        #endregion
    }
}