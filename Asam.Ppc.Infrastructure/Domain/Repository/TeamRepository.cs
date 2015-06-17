namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    using Ppc.Domain.OrganizationModule;

    public class TeamRepository : NHibernateRepositoryBase<Team>, ITeamRepository
    {
        #region Constructors and Destructors

        public TeamRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion
    }
}