using Commands.Builders.Abstractions;
using Content.Domain.Commands.Contexts;
using Domain.Entities.Abstraction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Domain.Commands.Extensions
{
    public static class CreateCommandContextExtensions
    {
        public static Task CreateAsync<T>(this IAsyncCommandBuilder asyncCommandBuilder, T entity, CancellationToken cancellationToken = default)
            where T : class, IEntity
        {
            return asyncCommandBuilder.ExecuteAsync(new CreateCommandContext<T>(entity), cancellationToken) ??
                throw new ArgumentNullException(nameof(asyncCommandBuilder));
        }
    }
}
