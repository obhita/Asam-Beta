using NHibernate;
using Pillar.Common.Configuration;
using Pillar.Common.InversionOfControl;
using Pillar.Domain;

namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    /// <summary>
    /// Defines NHibernte repoitory service.
    /// </summary>
    /// <typeparam name="T">The type, to be managed by the repository.</typeparam>
    public abstract class NHibernateRepositoryBase<T> where T : IAggregateRoot
    {
        private readonly ISessionProvider _sessionProvider;
        private NHibernateRepositoryHelper<T> _helper;

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateRepositoryBase&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="sessionProvider">The session provider.</param>
        protected internal NHibernateRepositoryBase ( ISessionProvider sessionProvider )
        {
            _sessionProvider = sessionProvider;
        }

        internal ISession Session
        {
            get
            {
                var session = _sessionProvider.GetSession ();
                return session;
            }
        }

        internal NHibernateRepositoryHelper<T> Helper
        {
            get
            {
                if ( _helper == null )
                {
                    _helper = new NHibernateRepositoryHelper<T>(_sessionProvider, IoC.CurrentContainer.Resolve<IConfigurationPropertiesProvider>());
                }
                return _helper;
            }
        }

        public T GetByKey(long key)
        {
            return Helper.GetEntityByKey ( key );
        }

        public T MakePersistent(T entity)
        {
            return Helper.MakePersistent ( entity );
        }

        public void MakeTransient(T entity)
        {
            Helper.MakeTransient ( entity );
        }
    }
}