using Flows.Primitives.Dependencies;
using Flows.Primitives.Exceptions;
using System;
using System.Threading.Tasks;

namespace Flows.Primitives.Query
{
    public interface IQueryProcessor
    {
        Task<TResult> ProcessAync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }

    public class QueryProcessor : IQueryProcessor
    {
        public QueryProcessor(IResolver resolver) => _resolver = resolver;

        private readonly IResolver _resolver;

        public async Task<TResult> ProcessAync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var handler = _resolver.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
                throw new HandlerNotFoundException();

            return await handler.HandleAsync(query);
        }
    }
}
