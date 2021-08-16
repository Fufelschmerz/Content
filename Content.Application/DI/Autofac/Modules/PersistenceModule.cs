using Autofac;
using Autofac.Extensions.ConfiguredModules;
using Content.Persistence.NHibernate;
using Content.Persistence.NHibernate.Repositories;
using Content.Persistence.NHibernate.Sessions;
using Content.Persistence.NHibernate.Sessions.Abstraction;
using Content.Persistence.NHibernate.Transactions.Behaviors;
using Microsoft.Extensions.Configuration;
using Repositories.Abstractions;

namespace Content.Application.DI.Autofac.Modules
{
    public class PersistenceModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            builder
                .RegisterGeneric(typeof(AsyncRepository<>))
                .As(typeof(IAsyncRepository<>))
                .InstancePerDependency();

            builder
                .RegisterType<ExpectCommitScopedSessionProvider>()
                .As<ISessionProvider>()
                .As<IExpectCommit>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<NHibernateInitializer>()
                .AsSelf()
                .SingleInstance()
                .WithParameter("сonnectionString", connectionString);

            builder
                .Register(context =>
                    context.Resolve<NHibernateInitializer>().GetConfiguration().BuildSessionFactory())
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
