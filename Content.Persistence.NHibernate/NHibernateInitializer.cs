using Content.Domain;
using Content.Persistence.NHibernate.Mappings.Entities.Location;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Content.Persistence.NHibernate
{
    public class NHibernateInitializer
    {
        private readonly string _connectionString;

        public NHibernateInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        private static bool ShouldExpose => true;

        private IPersistenceConfigurer GetDatabaseConfiguration() =>
            PostgreSQLConfiguration
            .Standard
            .Dialect("PostgreSQL82Dialect")
            .ConnectionString(_connectionString);


        private void Expose(Configuration configuration)
        {
#if DEBUG
            if (ShouldExpose)
            {
                new SchemaExport(configuration).Create(true, true);
            }
#endif
        }

        public Configuration GetConfiguration()
        {
            return Fluently.Configure()
                .Database(GetDatabaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateInitializer>())
                .ExposeConfiguration(Expose)
                .BuildConfiguration();
        }
    }
}
