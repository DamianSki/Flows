using System;

namespace Flows.Primitives.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        Guid AggregateRootId { get; set; }
        Guid CommandId { get; set; }
        DateTime TimeStamp { get; }
        void Update(ICommand command);
    }
}
