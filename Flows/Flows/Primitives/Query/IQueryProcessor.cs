using Flows.Primitives.Dependencies;
using Flows.Primitives.Exceptions;
using System;
using System.Threading.Tasks;

namespace Flows.Primitives.Query
{
    public interface IQueryProcessor
    {
        Task<TResult> ProcessAync<TResult>(IQuery<TResult> query);
    }

    public class QueryProcessor : IQueryProcessor
    {
        public QueryProcessor(IResolver resolver) => _resolver = resolver;

        private readonly IResolver _resolver;

        public async Task<TResult> ProcessAync<TResult>(IQuery<TResult> query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var handler = _resolver.Resolve<IQueryHandler<IQuery<TResult>, TResult>>();

            if (handler == null)
                throw new HandlerNotFoundException();

            return await handler.HandleAsync(query);
        }
    }
}
