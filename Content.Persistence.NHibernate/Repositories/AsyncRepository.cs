using Domain.Entities.Abstraction;
using LinqSpecs;
using NHibernate;
using NHibernate.Linq;
using Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Persistence.NHibernate.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T: class, IEntity
    {
        private readonly ISession _session;

        public AsyncRepository(ISession session)
        {
            _session = session ??
                throw new ArgumentNullException(nameof(session));
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _session.SaveAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _session.DeleteAsync(entity, cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(Specification<T> specification, CancellationToken cancellationToken = default)
        {
            return await _session.Query<T>().FirstOrDefaultAsync(specification, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _session.Query<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _session.Query<T>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
