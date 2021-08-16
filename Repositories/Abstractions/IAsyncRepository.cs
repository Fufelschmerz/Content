using Domain.Entities.Abstraction;
using LinqSpecs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.Abstractions
{
    public interface IAsyncRepository<T> where T : class, IEntity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> FirstOrDefaultAsync(Specification<T> specification, CancellationToken cancellationToken = default);
    }
}
