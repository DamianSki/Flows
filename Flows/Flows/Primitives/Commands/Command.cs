using System;

namespace Flows.Primitives.Commands
{
    public abstract class Command : ICommand
    {
        public Command() { }

        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Guid AggregateRootId { get; set; }
        public int UserId { get; set; }        
    }
}
