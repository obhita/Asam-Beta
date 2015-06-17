using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    using Ppc.Infrastructure;

    public class PatientAccessControlManager : IPatientAccessControlManager
    {
        public bool CanAccessAllPatients
        {
            get
            {
                var claimsPrincipal = GetClaimsPrincipal();
                return claimsPrincipal.Claims.Any(c => c.Type == AsamClaimTypes.AllPatientsClaimType);
            }
        }

        public bool CanAccessPatient(long patientKey)
        {
            var claimsPrincipal = GetClaimsPrincipal();
            return CanAccessAllPatients || claimsPrincipal.Claims.Any(c => c.Type == AsamClaimTypes.PatientIdClaimType && c.Value == patientKey.ToString());
        }

        private static ClaimsPrincipal GetClaimsPrincipal()
        {
            if(HttpContext.Current == null || HttpContext.Current.User == null)
            {
                return Thread.CurrentPrincipal as ClaimsPrincipal;
            }
            return HttpContext.Current.User as ClaimsPrincipal;
        }

        public static string GetCurrentUserName()
        {
            var claimsPrincipal = GetClaimsPrincipal();
            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name );
            return claim == null ? string.Empty : claim.Value;
        }
    }
}
