using AutoMapper;
using Flows.Primitives.Dependencies;
using Flows.Primitives.Domain;
using Flows.Primitives.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flows.Primitives.Commands
{
    public class CommandSender : ICommandSender
    {

        public CommandSender(IHandlerResolver resolver, IEventPublisher publisher, IStorage storage, IMapper mapper)
        {
            _resolver = resolver;
            _publisher = publisher;
            _storage = storage;
            _mapper = mapper;
        }

        private readonly IHandlerResolver _resolver;
        private readonly IEventPublisher _publisher;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public async Task<CommandResponse> SendAsync<TCommand>(TCommand command) where TCommand : ICommand 
            => await ProcessAsync(command);

        private async Task<CommandResponse> ProcessAsync<TCommand>(TCommand command) where TCommand : ICommand 
        {
            if (command == null)
                throw new ArgumentNullException();

            var handler = ResolveCommandHandler<TCommand>();

            var result = await handler.ExecuteAsync(command);

            if (result == null || result.Events == null)
                return null;

            var events = result.Events.ToList();

            events.ForEach(e => e.Update(command));

            await _storage.SaveAsync(new StoreData
            {
                AggregateRootId = command.AggregateRootId,
                Command = command,
                Events = events
            });

            events.ForEach(async e => await _publisher.PublishAsync((dynamic)_mapper.Map(e, e.GetType(), e.GetType())));

            return result;
        }

        private ICommandHandler<TCommand> ResolveCommandHandler<TCommand>() where TCommand : ICommand => _resolver.ResolveHandler<ICommandHandler<TCommand>>();
    }
}
