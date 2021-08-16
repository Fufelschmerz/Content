using Content.Domain.Entities.Location;
using FluentNHibernate.Mapping;

namespace Content.Persistence.NHibernate.Mappings.Entities.Location
{
    public class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Table("Countries");
            Id(x => x.Id, "CountryId");
            Map(x => x.Name, "CountryName").Length(255);
        }
    }
}
