using System;

namespace Asam.Ppc.Domain.Common
{
    /// <summary>
    /// The builder can be used to build blank entity with id or generate id for the existing entity.
    /// </summary>
    public interface IEntityBuilder
    {
        /// <summary>
        /// Build blank entity with id.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="buildAction"> </param>
        /// <returns></returns>
        TEntity Build<TEntity>(Action<TEntity> buildAction = null) where TEntity : Entity;

        /// <summary>
        /// Build up the specific entity to generate id for it.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="buildAction"> </param>
        /// <returns></returns>
        TEntity BuildUp<TEntity>(TEntity entity, Action<TEntity> buildAction = null) where TEntity : Entity;

        /// <summary>
        /// Build blank entity with id.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="buildAction"> </param>
        /// <returns></returns>
        TEntity Build<TEntity, TId>(Action<TEntity> buildAction = null) where TEntity : Entity<TId>;

        /// <summary>
        /// Build up the specific entity to generate id for it.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="entity"></param>
        /// <param name="buildAction"> </param>
        /// <returns></returns>
        TEntity BuildUp<TEntity, TId>(TEntity entity, Action<TEntity> buildAction = null) where TEntity : Entity<TId>;
    }
}