using Content.Domain.Entities.Location;
using LinqSpecs;
using System;
using System.Linq.Expressions;

namespace Content.Persistence.ORM.Queries.Entities.Countries.Specifications
{
    public class CountrySpecificationByName : Specification<Country>
    {
        public string Name { get; }

        public CountrySpecificationByName(string name)
        {
            Name = name ??
                throw new ArgumentNullException(nameof(name));
        }

        public override Expression<Func<Country, bool>> ToExpression()
        {
            return c => c.Name == Name;
        }
    }
}
