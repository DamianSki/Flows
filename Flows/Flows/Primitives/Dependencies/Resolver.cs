using Flows.Primitives.Exceptions;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Flows.Primitives.Dependencies
{
    public class Resolver : IResolver
    {
        public Resolver(IServiceProvider service) => _service = service;

        private readonly IServiceProvider _service;

        public THandler Resolve<THandler>()
        {            
            var handler = _service.GetService<THandler>();

            if (handler == null)
                throw new HandlerNotFoundException(typeof(THandler));

            return handler;
        }

        public object Resolve(Type handlerType)
        {
            var handler = _service.GetService(handlerType);

            if (handler == null)
                throw new HandlerNotFoundException(handlerType);

            return handler;
        }

        public IEnumerable<THandler> ResolveAll<THandler>() => _service.GetServices<THandler>();
    }
}
