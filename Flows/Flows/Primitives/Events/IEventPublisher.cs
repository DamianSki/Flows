using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flows.Primitives.Events
{
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish event asynchronously
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event">IEvent</param>
        /// <returns></returns>
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
        /// <summary>
        /// Publish events asynchronously 
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="events">Events to pulish</param>
        /// <returns></returns>
        Task PublishAsync<TEvent>(IEnumerable<TEvent> @events) where TEvent : IEvent;
    }
}
