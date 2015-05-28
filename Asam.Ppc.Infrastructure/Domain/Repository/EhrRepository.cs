namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    #region Using Statements

    using Ppc.Domain.EhrModule;

    #endregion

    /// <summary>
    ///     Ehr repository.
    /// </summary>
    public class EhrRepository : NHibernateRepositoryBase<Ehr>, IEhrRepository
    {
        #region Constructors and Destructors

        public EhrRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion
    }
}