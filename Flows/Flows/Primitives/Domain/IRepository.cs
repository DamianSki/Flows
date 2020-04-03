using System;
using System.Threading.Tasks;

namespace Flows.Primitives.Domain
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// Save an aggregate asynchronously.
        /// </summary>
        /// <param name="aggregate">Aggregate.</param>
        /// <returns></returns>
        Task SaveAsync(TEntity aggregate);

        /// <summary>
        /// Get by identifier asynchronous.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id);
    }
}
