using Commands.Abstractions;
using Commands.Contexts.Abstractions;

namespace Commands.Factories.Abstractions
{
    public interface IAsyncCommandFactory
    {
        IAsyncCommand<TCommandContext> Create<TCommandContext>() where TCommandContext : ICommandContext;
    }
}
