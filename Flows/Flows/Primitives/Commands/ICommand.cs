using System;

namespace Flows.Primitives
{
    public interface ICommand
    {
        Guid Id { get; }
        Guid AggregateRootId { get; set; }
        int UserId { get; set; }
    }
}
