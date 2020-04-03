using System;

namespace Flows.Primitives.Domain
{
    interface IEntity
    {
        Guid Id { get; }
    }
}
