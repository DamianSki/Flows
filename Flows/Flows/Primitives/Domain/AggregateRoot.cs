using Flows.Primitives.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Flows.Primitives.Domain
{
    public class AggregateRoot : IAggregateRoot
    {
        public AggregateRoot() => Id = Guid.NewGuid();

        public Guid Id { get; protected set; }

        private readonly List<IEvent> _events = new List<IEvent>();
        public ReadOnlyCollection<IEvent> Events => _events.AsReadOnly();
        public void LoadsFromHistory(IEnumerable<IEvent> events) => events.ToList().ForEach(ApplyEvent);

        public void ApplyEvent(IEvent @event)
        {

        }

        /// <summary>
        /// Adds the event to the list.
        /// </summary>
        /// <param name="event">Event</param>
        protected void AddEvent(IEvent @event)
        {
            _events.Add(@event);
        }
    }
}
