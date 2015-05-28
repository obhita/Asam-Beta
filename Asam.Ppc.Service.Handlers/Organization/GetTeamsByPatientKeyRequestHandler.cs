namespace Asam.Ppc.Service.Handlers.Organization
{
    using System.Collections.Generic;
    using System.Linq;
    using Agatha.Common;
    using Common;
    using Domain.OrganizationModule;
    using Messages.Organization;
    using global::AutoMapper;

    public class GetTeamsByPatientKeyRequestHandler : NHibernateSessionRequestHandler<GetTeamsByPatientKeyRequest, DtoCollectionResponse<TeamSummaryDto>>
    {
        public override Response Handle(GetTeamsByPatientKeyRequest request)
        {
            var query = Session.QueryOver<Team>().Where(t => t.Patients.Any(s => s.Key == request.PatientKey));
            var response = CreateTypedResponse();
            response.Dtos = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamSummaryDto>>(query.List());
            return response;
        }
    }
}