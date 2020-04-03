﻿using Flows.Primitives.Events;
using System.Collections.Generic;

namespace Flows.Primitives.Commands
{
    public class CommandResponse
    {
        public IEnumerable<IEvent> Events { get; set; } = new List<IEvent>();
        public object Result { get; set; }

        public CommandResponse() { }

        public CommandResponse(IEvent @event, object result = null)
        {
            Events = new List<IEvent> { @event };
            Result = result;
        }
    }
}
