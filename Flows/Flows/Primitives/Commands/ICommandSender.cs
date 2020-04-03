using System.Threading.Tasks;

namespace Flows.Primitives.Commands
{
    public interface ICommandSender
    {
        /// <summary>
        /// Sends a command asynchronously.
        /// The command handler must implement Kledex.Commands.ICommandHandlerAsync&lt;TCommand&gt;.
        /// </summary>
        /// <param name="command">Command.</param>
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Sends a command asynchronously.        
        /// </summary>
        /// <param name="command">Command.</param>
        /// <returns></returns>
        Task<TResult> SendAsync<TResult>(ICommand command);
    }
}
