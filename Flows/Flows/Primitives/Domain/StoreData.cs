using Flows.Primitives.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flows.Primitives.Domain
{
    public class StoreData
    {
        public Guid AggregateRootId { get; set; }
        public ICommand Command { get; set; }
        public IEnumerable<IEvent> Events { get; set; }
    }
}
