using Autofac;
using Commands.Abstractions;
using Commands.Builders.Abstractions;
using Commands.Builders.Default;
using Commands.Factories.Abstractions;
using Content.Persistence.ORM;
using Content.Persistence.ORM.Commands.Defaults;
using Tados.Autofac.Extensions.TypedFactories;

namespace Content.Application.DI.Autofac.Modules
{
    public class CommandsModule : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(CreateEntityCommand<>))
                .As(typeof(IAsyncCommand<>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceOrmAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncCommand<>))
                .InstancePerDependency();

            builder
                .RegisterGenericTypedFactory<IAsyncCommandFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AsyncCommandBuilder>()
                .As<IAsyncCommandBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}
