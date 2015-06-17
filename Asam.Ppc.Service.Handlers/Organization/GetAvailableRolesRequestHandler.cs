namespace Asam.Ppc.Service.Handlers.Organization
{
    using System.Collections.Generic;
    using System.Linq;
    using Agatha.Common;
    using Common;
    using Domain.OrganizationModule;
    using Domain.SecurityModule;
    using Infrastructure;
    using Messages.Security;
    using global::AutoMapper;

    public class GetAvailableRolesRequestHandler : NHibernateSessionRequestHandler<GetAvailableRolesRequest, GetAvailableRolesResponse>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ISystemAccountRepository _systemAccountRepository;

        public GetAvailableRolesRequestHandler(IStaffRepository staffRepository, ISystemAccountRepository systemAccountRepository)
        {
            _staffRepository = staffRepository;
            _systemAccountRepository = systemAccountRepository;
        }

        private class RoleComparer : IEqualityComparer<Role>
        {
            public bool Equals ( Role x, Role y )
            {
                if ( x == null && y == null )
                {
                    return true;
                }
                if ( x == null || y == null )
                {
                    return false;
                }
                return x.Key.Equals ( y.Key );
            }

            public int GetHashCode ( Role obj )
            {
                return obj.Key.GetHashCode ();
            }
        }

        public override Response Handle ( GetAvailableRolesRequest request )
        {
            var response = CreateTypedResponse ();
            var staff = _staffRepository.GetByKey ( request.Key );
            var systemAccount = _systemAccountRepository.GetByStaffKey ( staff.Key );
            var allRoles = Session.QueryOver<Role> ()
                                  .Where ( r => r.RoleType != RoleType.Internal )
                                  .JoinQueryOver ( r => r.Organization )
                                  .Where ( o => o.Key == UserContext.OrganizationKey )
                                  .List ();
            if ( systemAccount == null || systemAccount.Roles == null || !systemAccount.Roles.Any () )
            {
                response.Roles = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>> ( allRoles );
            }
            else
            {
                var currentRoles = systemAccount.Roles.Select(sar => sar.Role);
                var availableRoles = allRoles.Except ( currentRoles, new RoleComparer ());
                response.Roles = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>> ( availableRoles );
            }
            if ( response.Roles == null )
            {
                response.Roles = Enumerable.Empty<RoleDto> ();
            }
            return response;
        }
    }
}
