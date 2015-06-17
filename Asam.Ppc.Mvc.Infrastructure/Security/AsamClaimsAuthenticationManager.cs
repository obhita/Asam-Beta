using System.Security.Claims;

namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Domain.SecurityModule;
    using NLog;
    using Pillar.Common.InversionOfControl;
    using Ppc.Infrastructure;
    using Ppc.Infrastructure.Domain;

    public class AsamClaimsAuthenticationManager : ClaimsAuthenticationManager
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #region Public Methods

        /// <summary>
        /// Authenticates a specified resource by its name.
        /// </summary>
        /// <param name="resourceName">
        /// Name of the resource. 
        /// </param>
        /// <param name="claimsPrincipal">
        /// The claims principal. 
        /// </param>
        /// <returns>
        /// Returns claims principal for given resource 
        /// </returns>
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                var identity = claimsPrincipal.Identity as ClaimsIdentity;
                    if (identity != null)
                    {
                        identity.AddClaim ( new Claim ( AsamClaimTypes.AllPatientsClaimType, string.Empty ) );
                    //Note:  NameIdentitider is email by default if it is provided in Identity Server. If email is empty, then nameIdentifier takes username.
                    // This is not the case any more since July 2013 commits
                    var claim = identity.Claims.FirstOrDefault ( c => c.Type == ClaimTypes.NameIdentifier ) ?? identity.Claims.FirstOrDefault ( c => c.Type == ClaimTypes.Email );
                    
                    var nameIdentifier = claim.Value;

                    //make sure nameIdentifier is email address:
                    var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (!regex.IsMatch(nameIdentifier))
                    {
                        nameIdentifier = identity.Claims.First(c => c.Type == ClaimTypes.Email).Value;
                    }

                    Logger.Debug ( "Name identifier for authenticated principal ({0}): {1}.", identity.Name, nameIdentifier );

                    Logger.Debug ( "Resolving dependency on ISystemAccountRepository." );
                    var systemAccountRepository = IoC.CurrentContainer.Resolve<ISystemAccountRepository> ();
                    Logger.Debug ( "Resolved dependency on ISystemAccountRepository." );

                    var systemAccount = systemAccountRepository.GetByIdentifier ( nameIdentifier );

                    if ( systemAccount != null )
                    {
                        Logger.Debug ( "Resolving dependency on {0}.", typeof(IPermissionClaimsManager).Name );
                        var permissionClaimsManager = IoC.CurrentContainer.Resolve<IPermissionClaimsManager> ();
                        Logger.Debug ( "Resolved dependency on {0}.", typeof(IPermissionClaimsManager).Name );

                        Logger.Debug ( "Issue more claims for ({0} ({1}))", systemAccount.Identifier, systemAccount.Email.Address );
                        permissionClaimsManager.IssueSystemPermissionClaims ( claimsPrincipal, systemAccount );
                        permissionClaimsManager.IssueAccountStaffClaims(claimsPrincipal, systemAccount);

                        systemAccount.LoggedIn();
                        var session = IoC.CurrentContainer.Resolve<ISessionProvider>().GetSession();
                        session.Save(systemAccount);
                        session.Flush();
                    }
                    else
                    {
                        var errorMessage = string.Format (
                                                          "Authenticated principal ({0}) with identifier ({1}) does not have a system account in PRO Center.",
                                                          identity.Name,
                                                          nameIdentifier );
                        Logger.Error( errorMessage );
                    }
                }
            else
            {
                Logger.Debug ( "Incoming IClaimsPrincipal was not authenticated. WIF will redirect the request to the identity server." );
            }
            }

            return claimsPrincipal;
        }

        #endregion
    }
}
