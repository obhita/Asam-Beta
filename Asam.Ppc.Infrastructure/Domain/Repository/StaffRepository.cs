namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    using Ppc.Domain.OrganizationModule;

    public class StaffRepository : NHibernateRepositoryBase<Staff>, IStaffRepository
    {
        #region Constructors and Destructors

        public StaffRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion
    }
}