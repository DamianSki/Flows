using System;

namespace Flows.Primitives.Events
{
    public abstract class Event : IEvent
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime TimeStamp { get; protected set; } = DateTime.UtcNow;
        public Guid AggregateRootId { get; set; }
        public Guid CommandId { get; set; }
        public int UserId { get; set; }

        public void Update(ICommand command)
        {
            CommandId = command.Id;
            UserId = command.UserId;
            AggregateRootId = command.AggregateRootId;
        }
    }
}
