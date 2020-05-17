using System;
using System.Collections.Generic;

namespace Flows.Primitives.Dependencies
{
    public interface IResolver
    {
        THandler Resolve<THandler>();
        object Resolve(Type handlerType);

        IEnumerable<THandler> ResolveAll<THandler>();
    }
}
