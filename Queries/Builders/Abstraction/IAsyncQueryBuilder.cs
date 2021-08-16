using Queries.Abstractions;

namespace Queries.Builders.Abstraction
{
    public interface IAsyncQueryBuilder
    {
        IAsyncQueryFor<TResult> For<TResult>();
    }
}
