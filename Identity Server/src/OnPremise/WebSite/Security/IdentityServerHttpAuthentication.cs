namespace Thinktecture.IdentityServer.Web.Security
{
    #region

    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Security.Cryptography.X509Certificates;
    using System.Web;
    using IdentityModel;
    using IdentityModel.Tokens.Http;
    using NLog;
    using Repositories;

    #endregion

    public class IdentityServerHttpAuthentication : HttpAuthentication
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IConfigurationRepository _configurationRepository;

        public IdentityServerHttpAuthentication(AuthenticationConfiguration configuration, IConfigurationRepository configurationRepository)
            : base(configuration)
        {
            _configurationRepository = configurationRepository;
        }

        public override ClaimsPrincipal AuthenticateSessionToken(HttpRequestMessage request)
        {
            // grab header
            var headerValues = request.Headers.SingleOrDefault(h => h.Key == Configuration.SessionToken.HeaderName).Value;
            if (headerValues != null)
            {
                var header = headerValues.SingleOrDefault();
                if (header != null)
                {
                    var parts = header.Split(' ');
                    if (parts.Length == 2)
                    {
                        // if configured scheme was sent, try to authenticate the session token
                        Logger.Debug("Scheme: {0}", parts[0]);
                        if (parts[0] == Configuration.SessionToken.Scheme)
                        {
                            var token = new JwtSecurityToken(parts[1]);
                            Logger.Debug("token: {0}", token);
                            Logger.Debug("Thumbprint: {0}", _configurationRepository.Keys.SigningCertificate.Thumbprint);
                            if (_configurationRepository.Keys.SigningCertificate.Thumbprint != null)
                            {
                                var store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);
                                store.Open(OpenFlags.ReadOnly);
                                var cert = store.Certificates.Find(X509FindType.FindByThumbprint, _configurationRepository.Keys.SigningCertificate.Thumbprint, false)[0];
                                store.Close();

                                Logger.Debug("cert: {0}", cert);

                                var validationParameters = new TokenValidationParameters
                                    {
                                        ValidIssuer = _configurationRepository.Global.IssuerUri,
                                        AllowedAudience =
                                            HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                                            HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/" + Configuration.SessionToken.Audience,
                                        SigningToken = new X509SecurityToken(cert),
                                    };
                                Logger.Debug("validationParameters: {0}", validationParameters);
                                Logger.Debug("ValidIssuer: {0}", validationParameters.ValidIssuer);
                                Logger.Debug("AllowedAudience: {0}", validationParameters.AllowedAudience);
                                Logger.Debug("SigningToken: {0}", validationParameters.SigningToken);

                                var handler = new JwtSecurityTokenHandler();
                                var result = handler.ValidateToken(token, validationParameters);
                                Logger.Debug("Validate result: {0}", result);
                                return result;
                            }
                        }
                    }
                }
            }

            return Principal.Anonymous;
        }
    }
}