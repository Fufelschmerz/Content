using Content.Domain.Queries.Criteria;
using Content.Persistence.ORM.Queries.Repository;
using Domain.Entities.Abstraction;
using Repositories.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Persistence.ORM.Queries.Defaults
{
    public class FindByIdQuery<T> : RepositoryAsyncQueryBase<T, FindById, T>
        where T : class, IEntity
    {
        public FindByIdQuery(IAsyncRepository<T> repository) : base(repository)
        {

        }

        public override Task<T> AskAsync(FindById criterion, CancellationToken cancellationToken = default)
        {
            return Repository.GetByIdAsync(criterion.Id, cancellationToken);
        }
    }
}
