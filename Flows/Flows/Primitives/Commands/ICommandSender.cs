using System.Threading.Tasks;

namespace Flows.Primitives.Commands
{
    public interface ICommandSender
    {
        /// <summary>
        /// Sends a command asynchronously.        
        /// </summary>
        /// <param name="command">Command.</param>
        /// <returns>Command response.</returns>
        Task<CommandResponse> SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
