using System;

namespace Asam.Ppc.Infrastructure.Domain
{
    /// <summary>
    /// Unit of Work to manage a group of changes.
    /// <remarks>The life time of unit of work is usually "per call" (e.g. Request in web, Operation Context in WCF, or Thread in unit test) </remarks>
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork Start();

        void Commit();
    }
}