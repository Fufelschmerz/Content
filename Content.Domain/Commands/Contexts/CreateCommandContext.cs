using Commands.Contexts.Abstractions;
using Domain.Entities.Abstraction;
using System;

namespace Content.Domain.Commands.Contexts
{
    public class CreateCommandContext<T> : ICommandContext where T : class, IEntity
    {
        public CreateCommandContext(T entity)
        {
            Entity = entity ??
                throw new ArgumentNullException(nameof(entity));
        }

        public T Entity { get; }
    }
}
