using Queries.Abstractions;
using Queries.Criterions.Abstraction;
using Queries.Factories.Abstraction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.Builders.Default
{
    public class AsyncQueryFor<TResult> : IAsyncQueryFor<TResult>
    {
        private readonly IAsyncQueryFactory _queryFactory;

        public AsyncQueryFor(IAsyncQueryFactory queryFactory)
        {
            if (queryFactory == null)
                throw new ArgumentNullException(nameof(queryFactory));

            _queryFactory = queryFactory;
        }

        public Task<TResult> WithAsync<TCriterion>(TCriterion criterion, CancellationToken cancellationToken = default) 
            where TCriterion : ICriterion
        {
            return _queryFactory.Create<TCriterion, TResult>().AskAsync(criterion, cancellationToken);
        }
    }
}
