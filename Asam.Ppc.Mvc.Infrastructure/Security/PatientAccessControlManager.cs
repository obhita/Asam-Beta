namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    #region Using Statements

using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

    using Agatha.Common;

    using Asam.Ppc.Infrastructure;
    using Asam.Ppc.Service.Messages.Core;

    #endregion

    public class PatientAccessControlManager : IPatientAccessControlManager
{
        #region Fields

        private readonly IRequestDispatcherFactory _requestDispatcherFactory;

        #endregion

        #region Constructors and Destructors

        public PatientAccessControlManager ( IRequestDispatcherFactory requestDispatcherFactory )
    {
            _requestDispatcherFactory = requestDispatcherFactory;
        }

        #endregion

        #region Public Properties

        public bool CanAccessAllPatients
        {
            get
            {
                var claimsPrincipal = GetClaimsPrincipal ();
                return claimsPrincipal.Claims.Any ( c => c.Type == AsamClaimTypes.AllPatientsClaimType );
            }
        }

        #endregion

        #region Public Methods and Operators

        public static string GetCurrentUserName ()
        {
            if ( SingleSignOnHelper.IsApiMode () )
            {
                return SingleSignOnHelper.GetSingleSignOnUserName ( HttpContext.Current.ApplicationInstance );
            }

            var claimsPrincipal = GetClaimsPrincipal ();
            var claim = claimsPrincipal.Claims.FirstOrDefault ( c => c.Type == ClaimTypes.Name );
            return claim == null ? string.Empty : claim.Value;
        }

        public bool CanAccessPatient ( long patientKey )
        {
            if ( SingleSignOnHelper.IsApiMode () )
            {
                var singleSignOn = SingleSignOnHelper.GetSingleSignOnParameters ( HttpContext.Current.ApplicationInstance );
                var requestDispatcher = _requestDispatcherFactory.CreateRequestDispatcher ();
                requestDispatcher.Add ( new GetPatientDtoByKeyRequest { PatientKey = patientKey } );
                var response = requestDispatcher.Get<GetPatientDtoResponse> ();
                var patientDto = response.Dto as PatientDto;

                return patientDto != null && patientDto.OrganizationKey.ToString () == singleSignOn.OrganizationId;
            }

            var claimsPrincipal = GetClaimsPrincipal ();
            return CanAccessAllPatients || claimsPrincipal.Claims.Any ( c => c.Type == AsamClaimTypes.PatientIdClaimType && c.Value == patientKey.ToString () );
        }

        #endregion

        #region Methods

        private static ClaimsPrincipal GetClaimsPrincipal ()
        {
            if ( HttpContext.Current == null || HttpContext.Current.User == null )
            {
                return Thread.CurrentPrincipal as ClaimsPrincipal;
            }
            return HttpContext.Current.User as ClaimsPrincipal;
        }

        #endregion
    }
}
