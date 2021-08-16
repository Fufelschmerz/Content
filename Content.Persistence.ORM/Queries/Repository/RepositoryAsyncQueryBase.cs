using Domain.Entities.Abstraction;
using Queries.Abstractions;
using Queries.Criterions.Abstraction;
using Repositories.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Persistence.ORM.Queries.Repository
{
    public abstract class RepositoryAsyncQueryBase<T, TCriterion, TResult> : IAsyncQuery<TCriterion, TResult>
        where T : class, IEntity
        where TCriterion : ICriterion
    {
        protected RepositoryAsyncQueryBase(IAsyncRepository<T> repository)
        {
            Repository = repository;
        }

        protected IAsyncRepository<T> Repository { get; }


        public abstract Task<TResult> AskAsync(TCriterion criterion, CancellationToken cancellationToken = default);
    }
}
