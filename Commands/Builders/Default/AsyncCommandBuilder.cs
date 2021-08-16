using Commands.Builders.Abstractions;
using Commands.Contexts.Abstractions;
using Commands.Factories.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.Builders.Default
{
    public class AsyncCommandBuilder : IAsyncCommandBuilder
    {
        private readonly IAsyncCommandFactory _commandFactory;

        public AsyncCommandBuilder(IAsyncCommandFactory commandFactory)
        {
            _commandFactory = commandFactory ?? 
                throw new ArgumentNullException(nameof(commandFactory));
        }

        public Task ExecuteAsync<TCommandContext>(TCommandContext commandContext, CancellationToken cancellationToken = default) 
            where TCommandContext : ICommandContext
        {
            return _commandFactory.Create<TCommandContext>().ExecuteAsync(commandContext, cancellationToken);
        }
    }
}
