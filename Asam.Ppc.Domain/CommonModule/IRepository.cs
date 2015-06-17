namespace Asam.Ppc.Domain.Common
{
    public interface IRepository<TEntity, in TId> where TEntity : class, IAggregate
    {
        /// <summary>
        /// Get the entity by id, throws <exception cref="RecordNotFoundException">RecordNotFoundException</exception> if entity doesn't exist.
        /// </summary>
        /// <param name="id">Document Id.</param>
        /// <returns>An entity.</returns>
        TEntity Get(TId id);

        /// <summary>
        /// Try get the entity by id, returns null if entity doesn't exist.
        /// </summary>
        /// <param name="id">Document Id.</param>
        /// <returns>An entity.</returns>
        TEntity TryGet(TId id);

        /// <summary>
        /// Save new entity. Don't use this method for updating entity, unit of work handles it during commit.
        /// </summary>
        /// <param name="entity">Entity document.</param>
        /// <returns>An entity.</returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Delete the existing entity.
        /// </summary>
        /// <param name="entity">An entity.</param>
        void Delete(TEntity entity);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, string>
        where TEntity : class, IAggregate
    {
    }
}
