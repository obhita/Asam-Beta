namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    #region Using Statements

    using Pillar.Domain;
    using Ppc.Domain.CommonModule;
    using global::NHibernate;

    #endregion

    /// <summary>
    ///     A helper class for NHibernate repository to get session, save and delete entity.
    /// </summary>
    /// <typeparam name="T">An IAggregateRoot type.</typeparam>
    internal class NHibernateRepositoryHelper<T> where T : IAggregateRoot
    {
        #region Fields

        private readonly ISessionProvider _sessionProvider;

        #endregion

        #region Constructors and Destructors

        public NHibernateRepositoryHelper ( ISessionProvider sessionProvider )
        {
            _sessionProvider = sessionProvider;
        }

        #endregion

        #region Properties

        internal ISession Session
        {
            get
            {
                var session = _sessionProvider.GetSession ();
                return session;
            }
        }

        #endregion

        #region Public Methods and Operators

        public T GetEntityByKey ( long key, bool eager = false )
        {
            var entity = Session.Get<T> ( key );
            if ( entity is IOrganizationMember )
            {
                if ( !UserContext.IsSystemAdmin && ( entity as IOrganizationMember ).OrganizationKey != UserContext.OrganizationKey )
                {
                    return default(T);
                }
            }
            return entity;
        }

        public T MakePersistent ( T entity )
        {
            Session.SaveOrUpdate ( entity );
            return entity;
        }

        public void MakeTransient ( T entity )
        {
            Session.Delete ( entity );
        }

        #endregion
    }
}