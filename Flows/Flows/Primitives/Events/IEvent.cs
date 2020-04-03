using System;

namespace Flows.Primitives.Events
{
    public interface IEvent
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
        Guid CommandId { get; set; }
        DateTime TimeStamp { get; set; }
        void Update(ICommand command);
    }
}
