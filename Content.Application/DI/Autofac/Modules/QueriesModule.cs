using Autofac;
using Content.Persistence.ORM;
using Content.Persistence.ORM.Queries.Defaults;
using Queries.Abstractions;
using Queries.Builders.Abstraction;
using Queries.Builders.Default;
using Queries.Factories.Abstraction;
using Tados.Autofac.Extensions.TypedFactories;

namespace Content.Application.DI.Autofac.Modules
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(FindByIdQuery<>))
                .As(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceOrmAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(AsyncQueryFor<>))
                .As(typeof(IAsyncQueryFor<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}
