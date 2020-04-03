using System;

namespace Flows.Primitives.Events
{
    public abstract class Event : IEvent
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
