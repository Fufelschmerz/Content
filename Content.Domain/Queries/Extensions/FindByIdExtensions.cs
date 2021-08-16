using Content.Domain.Queries.Criteria;
using Domain.Entities.Abstraction;
using Queries.Builders.Abstraction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Domain.Queries.Extensions
{
    public static class FindByIdExtensions
    {
        public static Task<T> FindByIdAsync<T>(this IAsyncQueryBuilder asyncQueryBuilder, long id, CancellationToken cancellationToken = default)
            where T : class, IEntity
        {
            if (asyncQueryBuilder == null)
                throw new ArgumentNullException(nameof(asyncQueryBuilder));

            return asyncQueryBuilder.For<T>().WithAsync(new FindById(id), cancellationToken);
        }
    }
}
