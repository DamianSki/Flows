using System;

namespace Flows.Primitives.Commands
{
    public abstract class Command : ICommand
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Guid AggregateRootId { get; set; }
    }
}
