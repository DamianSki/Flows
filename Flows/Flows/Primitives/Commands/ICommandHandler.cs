﻿using System.Threading.Tasks;

namespace Flows.Primitives.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<CommandResponse> HandleAsync(TCommand command);
    }
}
