namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    using System.Linq;
    using System.Security.Claims;
    using Domain.OrganizationModule;
    using Domain.SecurityModule;
    using Ppc.Infrastructure;

    public class PermissionClaimsManager : IPermissionClaimsManager
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;
        private readonly IStaffRepository _staffRepository;

        #endregion

        #region Constructors and Destructors

        public PermissionClaimsManager(IStaffRepository staffRepository, IRoleRepository roleRepository)
        {
            _staffRepository = staffRepository;
            _roleRepository = roleRepository;
        }

        #endregion

        #region Public Methods and Operators

        public void IssueAccountStaffClaims(ClaimsPrincipal claimsPrincipal, SystemAccount systemAccount)
        {
            var identity = claimsPrincipal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                identity.AddClaim(new Claim(AsamClaimTypes.AccountIdClaimType, systemAccount.Key.ToString()));
                if ( systemAccount.IsSystemAdmin )
                {
                    identity.AddClaim ( new Claim ( AsamClaimTypes.SystemAdminType, true.ToString() ) );
                }
                else 
                {
                    identity.AddClaim ( new Claim ( AsamClaimTypes.OrganizationIdClaimType, systemAccount.Organization.Key.ToString () ) );
                    identity.AddClaim ( new Claim ( AsamClaimTypes.OrganizationNameClaimType, systemAccount.Organization.Name ) );
                }
                var emailClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (emailClaim != null)
                {
                    identity.RemoveClaim(emailClaim);
                }
                identity.AddClaim(new Claim(ClaimTypes.Email, systemAccount.Email.Address));

                if (systemAccount.Staff != null)
                {
                    identity.AddClaim(new Claim(AsamClaimTypes.StaffIdClaimType, systemAccount.Staff.Key.ToString()));
                    identity.AddClaim(new Claim(AsamClaimTypes.StaffFullNameClaimType, systemAccount.Staff.Name.FirstName + " " + systemAccount.Staff.Name.LastName));
                }
            }
        }

        public void IssueSystemPermissionClaims(ClaimsPrincipal claimsPrincipal, SystemAccount systemAccount)
        {
            var identity = claimsPrincipal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                foreach (var role in systemAccount.Roles.Select ( sar => sar.Role ))
                {
                    foreach (var permission in role.Permissions)
                    {
                        identity.AddClaim(new Claim(AsamClaimTypes.PermissionClaimType, permission.SystemPermission.WellKnownName));
                    }
                }
            }
        }

        #endregion
    }
}