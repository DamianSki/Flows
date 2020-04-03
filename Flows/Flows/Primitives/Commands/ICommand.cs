using System;

namespace Flows.Primitives
{
    public interface ICommand
    {
        Guid Id { get; set; }
        Guid AggregateRootId { get; set; }
    }
}
