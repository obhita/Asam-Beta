using System.Collections.Generic;
using Asam.Ppc.Mvc.Infrastructure.Service;

namespace Asam.Ppc.Mvc4.Models
{
    using Infrastructure.Services;

    public class AssessmentViewModel
    {
        public CompletenessResults Completeness { get; private set; }
        public IEnumerable<RouteInfo> OrderRoutes { get; private set; }
        public RouteInfo CurrentRoute { get; private set; }
        public RouteInfo PreviousRoute { get; private set; }
        public RouteInfo NextRoute { get; private set; }
        public bool IsComplete { get; private set; }

        public AssessmentViewModel (long assessmentKey, IRouteNavigationService routeNavigationService, string section, string subsection, CompletenessResults completeness )
        {
            Completeness = completeness;
            routeNavigationService.LoadAssessment ( assessmentKey );
            OrderRoutes = routeNavigationService.OrderedRouteInfoList;
            CurrentRoute = routeNavigationService.GetRouteInfoBySectionInfo ( section, subsection );
            PreviousRoute = routeNavigationService.GetPreviousRoute ( CurrentRoute );
            NextRoute = routeNavigationService.GetNextRoute ( CurrentRoute );
            IsComplete = completeness.NumberInComplete == 0;
        }
    }
}