namespace Asam.Ppc.Infrastructure
{
    using System.Security.Claims;
    using System.Threading;

    public static class UserContext 
    {
        public static long UserId { get { return long.Parse(GetClaim(AsamClaimTypes.StaffIdClaimType) ?? "-1"); } }

        public static string UserName { get { return GetClaim(AsamClaimTypes.StaffFullNameClaimType); } }

        public static string Email { get { return GetClaim(AsamClaimTypes.StaffEmailClaimType) ?? GetClaim ( ClaimTypes.Email ); } }

        public static long SystemAccountKey { get { return long.Parse(GetClaim(AsamClaimTypes.AccountIdClaimType) ?? "-1"); } }

        public static string OrganizationName { get { return GetClaim(AsamClaimTypes.OrganizationNameClaimType); } }
        public static long OrganizationKey { get { return long.Parse(GetClaim(AsamClaimTypes.OrganizationIdClaimType) ?? "-1"); } }

        public static bool IsSystemAdmin { get { return bool.Parse(GetClaim(AsamClaimTypes.SystemAdminType) ?? "false"); } }

        private static string GetClaim(string claimType)
        {
            var claimsPrinciple = Thread.CurrentPrincipal as ClaimsPrincipal;
            var claim = claimsPrinciple.FindFirst ( claimType );
            if(claim != null)
            {
                return claim.Value;
            }
            return null;
        }
    }
}
