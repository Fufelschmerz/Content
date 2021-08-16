using Queries.Abstractions;
using Queries.Criterions.Abstraction;

namespace Queries.Factories.Abstraction
{
    public interface IAsyncQueryFactory
    {
        IAsyncQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion;
    }
}
