namespace Asam.Ppc.Service.Handlers.Organization
{
    using System.Collections.Generic;
    using System.Linq;
    using Agatha.Common;
    using Common;
    using Domain.OrganizationModule;
    using Messages.Organization;
    using NHibernate.Transform;
    using global::AutoMapper;

    public class GetTeamsByStaffKeyRequestHandler : NHibernateSessionRequestHandler<GetTeamsByStaffKeyRequest, DtoCollectionResponse<TeamSummaryDto>>
    {
        public override Response Handle ( GetTeamsByStaffKeyRequest request )
        {
            var staff = new {Key = request.StaffKey};
            var query = Session.QueryOver<Team> ()
                               .JoinAlias ( t => t.Staff, () => staff )
                               .Where ( () => staff.Key == request.StaffKey )
                               .TransformUsing ( Transformers.DistinctRootEntity );
            var response = CreateTypedResponse ();
            response.Dtos = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamSummaryDto>> ( query.List () );
            return response;
        }
    }
}
