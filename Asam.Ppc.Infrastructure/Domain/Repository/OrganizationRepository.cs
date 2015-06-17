namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    #region Using Statements

    using Ppc.Domain.OrganizationModule;

    #endregion

    /// <summary>
    ///     Organization repository.
    /// </summary>
    public class OrganizationRepository : NHibernateRepositoryBase<Organization>, IOrganizationRepository
    {
        #region Constructors and Destructors

        public OrganizationRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion
    }
}