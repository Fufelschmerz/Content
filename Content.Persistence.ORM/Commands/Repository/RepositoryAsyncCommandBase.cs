using Commands.Abstractions;
using Commands.Contexts.Abstractions;
using Domain.Entities.Abstraction;
using Repositories.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Persistence.ORM.Commands.Repository
{
    public abstract class RepositoryAsyncCommandBase<T, TCommandContext> : IAsyncCommand<TCommandContext>
        where T : class, IEntity
        where TCommandContext : ICommandContext
    {
        protected RepositoryAsyncCommandBase(IAsyncRepository<T> repository)
        {
            Repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        protected IAsyncRepository<T> Repository { get; }

        public abstract Task ExecuteAsync(
            TCommandContext commandContext,
            CancellationToken cancellationToken = default);
    }
}
