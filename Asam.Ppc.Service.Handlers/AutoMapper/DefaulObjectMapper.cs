using System.Linq;
using AutoMapper;

namespace Asam.Ppc.Service.Handlers.AutoMapper
{
    /// <summary>
    /// The Defaul Object Mapper in the project.
    /// </summary>
    public class DefaulObjectMapper : IObjectMapper
    {
        #region Members of IObjectMapper

        /// <summary>
        /// Determines whether the specified context is match.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if the specified context is match; otherwise, <c>false</c>.</returns>
        public bool IsMatch(ResolutionContext context)
        {
            if (Mapper.GetAllTypeMaps().Count(m => m.SourceType == context.SourceType && m.DestinationType == context.DestinationType) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Maps the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <returns>The mapped object</returns>
        public object Map(ResolutionContext context, IMappingEngineRunner mapper)
        {
            Mapper.CreateMap(context.SourceType, context.DestinationType);

            return Mapper.Map(context.SourceValue, context.SourceType, context.DestinationType);
        }

        #endregion
    }
}
