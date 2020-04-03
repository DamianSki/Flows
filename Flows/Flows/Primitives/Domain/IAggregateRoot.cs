using Flows.Primitives.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Flows.Primitives.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
        ReadOnlyCollection<IEvent> Events { get; }
        void LoadsFromHistory(IEnumerable<IEvent> events);
    }
}
