using System.Collections.Generic;

namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    /// <summary>
    /// Interface for managing route navigation
    /// </summary>
    public interface IRouteNavigationService
    {
        /// <summary>
        /// Gets the next route.
        /// </summary>
        /// <param name="currentRoute">The current route.</param>
        /// <returns>The next route.</returns>
        RouteInfo GetNextRoute ( RouteInfo currentRoute );

        /// <summary>
        /// Gets the previous route.
        /// </summary>
        /// <param name="currentRoute">The current route.</param>
        /// <returns>The previous route.</returns>
        RouteInfo GetPreviousRoute ( RouteInfo currentRoute );

        /// <summary>
        /// Gets the initial route.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The initial route.
        /// </returns>
        RouteInfo GetInitialRoute ( long? key = null );

        /// <summary>
        /// Gets the ordered route info list.
        /// </summary>
        /// <value>The ordered route info list.</value>
        IReadOnlyCollection<RouteInfo> OrderedRouteInfoList { get; }

        /// <summary>
        /// Gets the route info by section info.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="subsection">The subsection.</param>
        /// <returns></returns>
        RouteInfo GetRouteInfoBySectionInfo ( string section, string subsection );

        /// <summary>
        /// Loads the assessment.
        /// </summary>
        /// <param name="assessmentKey">The assessment key.</param>
        void LoadAssessment ( long assessmentKey );
        
        /// <summary>
        /// Recalculates the next route info.
        /// </summary>
        /// <param name="nextRouteString">The next route string.</param>
        /// <returns></returns>
        RouteInfo RecalculateNextRouteInfo(string nextRouteString);
    }
}