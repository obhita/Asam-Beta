namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    #region Using Statements

    using System.IdentityModel.Services;

    #endregion

    public static class IdentityServerUtil
    {
        #region Public Properties

        public static string BaseAddress
        {
            get { return ( ( FederatedAuthentication.WSFederationAuthenticationModule ?? new WSFederationAuthenticationModule () ).Issuer.Replace ( "issue/wsfed", "" ) ); }
        }

        #endregion
    }
}