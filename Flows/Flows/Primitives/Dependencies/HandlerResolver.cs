﻿using Flows.Primitives.Exceptions;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Flows.Primitives.Dependencies
{
    public class HandlerResolver : IHandlerResolver
    {
        public HandlerResolver(IServiceProvider service) => _service = service;

        private readonly IServiceProvider _service;

        public THandler ResolveHandler<THandler>()
        {            
            var handler = _service.GetService<THandler>();

            if (handler == null)
                throw new HandlerNotFoundException(typeof(THandler));

            return handler;
        }

        public object ResolveHandler(Type handlerType)
        {
            var handler = _service.GetService(handlerType);

            if (handler == null)
                throw new HandlerNotFoundException(handlerType);

            return handler;
        }
    }
}
