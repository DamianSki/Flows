using Flows.Primitives.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flows.Primitives.Domain
{
    public interface IStorage
    {
        /// <summary>
        /// Save command execution data asynchronously to the database.
        /// </summary>
        /// <param name="request">Command execution result</param>
        /// <returns></returns>
        Task SaveAsync(StoreData request);

        /// <summary>
        /// Gets the events asynchronously.
        /// </summary>
        /// <param name="aggregateId">An aggregate identifier.</param>
        /// <returns>Events</returns>
        Task<IEnumerable<IEvent>> GetEventsAsync(Guid aggregateId);
    }

    internal class DefaultStorage : IStorage
    {
        public Task<IEnumerable<IEvent>> GetEventsAsync(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(StoreData request)
        {
            throw new NotImplementedException();
        }
    }
}
