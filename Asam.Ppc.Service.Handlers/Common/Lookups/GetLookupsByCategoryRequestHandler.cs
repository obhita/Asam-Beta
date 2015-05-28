namespace Asam.Ppc.Service.Handlers.Common.Lookups
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Linq;
    using Domain.CommonModule;
    using Messages.Common.Lookups;
    using global::AutoMapper;

    #endregion

    /// <summary>
    /// Handler for getting lookups by category.
    /// </summary>
    public class GetLookupsByCategoryRequestHandler : ServiceRequestHandler<GetLookupsByCategoryRequest, GetLookupsByCategoryResponse>
    {
        #region Methods

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( GetLookupsByCategoryRequest request, GetLookupsByCategoryResponse response )
        {
            var lookups = Lookup.GetAll ( request.Category ).ToList ();
            var lookupDtos = Mapper.Map<List<Lookup>, List<LookupDto>> ( lookups );
            response.Lookups = lookupDtos;
            response.Category = request.Category;
        }

        #endregion
    }
}