using System.Threading.Tasks;

namespace Flows.Primitives.Query
{
    interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
