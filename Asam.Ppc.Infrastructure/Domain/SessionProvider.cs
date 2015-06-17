using NHibernate;
using NHibernate.Context;

namespace Asam.Ppc.Infrastructure.Domain
{
    /// <summary>
    /// This class provides NHibernate session.
    /// </summary>
    public class SessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionProvider" /> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public SessionProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        #region ISessionProvider Members

        public ISessionFactory SessionFactory { get { return _sessionFactory; } }

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <returns>An ISession object.</returns>
        public ISession GetSession()
        {
            ISession session;
            if ( !CurrentSessionContext.HasBind ( _sessionFactory ) )
            {
                session = _sessionFactory.OpenSession ();
                CurrentSessionContext.Bind ( session );
            }
            else
            {
                session = _sessionFactory.GetCurrentSession ();
            }
            return session;
        }

        #endregion
    }
}
