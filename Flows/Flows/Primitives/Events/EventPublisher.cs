using Flows.Primitives.Dependencies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flows.Primitives.Events
{
    public class EventPublisher : IEventPublisher
    {
        public EventPublisher(IResolver resolver)
        {
            _resolver = resolver;
        }

        private readonly IResolver _resolver;
        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

            var handlers = _resolver.ResolveAll<IEventHandler<TEvent>>();

            foreach (var handler in handlers)
                await handler.HandleAsync(@event);
        }

        public async Task PublishAsync<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent
        {
            foreach (TEvent @event in events)
                await PublishAsync(@event);
        }
    }
}
