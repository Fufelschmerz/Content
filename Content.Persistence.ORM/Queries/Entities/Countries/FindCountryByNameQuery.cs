using Content.Domain.Entities.Location;
using Content.Domain.Queries.Criteria;
using Content.Persistence.ORM.Queries.Entities.Countries.Specifications;
using Content.Persistence.ORM.Queries.Repository;
using Repositories.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Persistence.ORM.Queries.Entities.Countries
{
    public class FindCountryByNameQuery : RepositoryAsyncQueryBase<Country, FindCountryByName, Country>
    {
        public FindCountryByNameQuery(IAsyncRepository<Country> repository) : base(repository)
        {

        }

        public override Task<Country> AskAsync(FindCountryByName criterion, CancellationToken cancellationToken = default)
        {
            var countrySpec = new CountrySpecificationByName(criterion.Name);

            return Repository.FirstOrDefaultAsync(countrySpec, cancellationToken);
        }
    }
}
