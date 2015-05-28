using NHibernate;

namespace Asam.Ppc.Infrastructure.Domain
{
    /// <summary>
    /// The <see cref="T:Asam.Ppc.Infrastructure.Domain.ISessionProvider"> ISessionProvider </see> defines utilities for NHibernate session.
    /// </summary>
    public interface ISessionProvider
    {
        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <returns> ISession object.</returns>
        ISession GetSession ();

        ISessionFactory SessionFactory { get; }
    }
}
