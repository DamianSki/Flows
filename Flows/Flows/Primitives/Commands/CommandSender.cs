using System.Threading.Tasks;

namespace Flows.Primitives.Commands
{
    public class CommandSender : ICommandSender
    {
        public CommandSender()
        {
        }

        public Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> SendAsync<TResult>(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
