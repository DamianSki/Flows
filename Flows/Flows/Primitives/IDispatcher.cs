using Flows.Primitives.Events;
using Flows.Primitives.Query;
using System.Threading.Tasks;

namespace Flows.Primitives
{
    public interface IDispatcher
    {
        /// <summary>
        /// Send command asynchronously.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command">ICommand</param>
        /// <returns></returns>
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        /// <summary>
        /// Publish event asynchronously.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event">IEvent</param>
        /// <returns></returns>
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;

        /// <summary>
        /// Asynchronously returns result.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query">IQuery</param>
        /// <returns>Result</returns>
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
