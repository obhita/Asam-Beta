using Agatha.Common;
using Agatha.ServiceLayer;
using Asam.Ppc.Infrastructure.Domain;
using NHibernate;
using StructureMap.Attributes;

namespace Asam.Ppc.Service.Handlers.Common
{
    public abstract class NHibernateSessionRequestHandler<TRequest, TResponse> : RequestHandler<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response, new()
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the session provider.
        /// </summary>
        /// <value> The session provider. </value>
        [SetterProperty]
        public ISessionProvider SessionProvider { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the session.
        /// </summary>
        protected ISession Session
        {
            get { return SessionProvider.GetSession(); }
        }

        #endregion
    }
}
