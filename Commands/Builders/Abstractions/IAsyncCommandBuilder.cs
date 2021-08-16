using Commands.Contexts.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.Builders.Abstractions
{
    public interface IAsyncCommandBuilder
    {
        Task ExecuteAsync<TCommandContext>(TCommandContext commandContext,
            CancellationToken cancellationToken = default) where TCommandContext : ICommandContext;
    }
}
