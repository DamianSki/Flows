using System;

namespace Flows.Primitives.Exceptions
{
    public class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(Type type) : base($"Handler {nameof(type)} not found")
        {

        }
    }
}
