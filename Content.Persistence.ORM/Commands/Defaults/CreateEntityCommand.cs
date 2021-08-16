using Content.Domain.Commands.Contexts;
using Content.Persistence.ORM.Commands.Repository;
using Domain.Entities.Abstraction;
using Repositories.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Persistence.ORM.Commands.Defaults
{
    public class CreateEntityCommand<T> : RepositoryAsyncCommandBase<T, CreateCommandContext<T>>
         where T : class, IEntity
    {
        public CreateEntityCommand(IAsyncRepository<T> repository) : base(repository) { }

        public override Task ExecuteAsync(CreateCommandContext<T> commandContext, CancellationToken cancellationToken = default)
        {
            return Repository.AddAsync(commandContext.Entity, cancellationToken);
        }
    }
}
