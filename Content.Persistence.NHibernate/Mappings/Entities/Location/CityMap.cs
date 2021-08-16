using Content.Domain.Entities.Location;
using FluentNHibernate.Mapping;

namespace Content.Persistence.NHibernate.Mappings.Entities.Location
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Table("Cities");
            SchemaAction.None();
            Id(x => x.Id, "CityId");
            Map(x => x.Name, "CityName").Length(255);
            HasOne(x => x.Country).Cascade.All().Constrained();
        }
    }
}
