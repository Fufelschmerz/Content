using Content.Domain.Entities.Location;
using Content.Domain.Queries.Criteria;
using Content.Persistence.ORM.Queries.Repository;
using Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Persistence.ORM.Queries.Entities.Countries
{
    public class FindAllCountriesQuery : RepositoryAsyncQueryBase<Country, FindAllCountries, List<Country>>
    {
        public FindAllCountriesQuery(IAsyncRepository<Country> repository) : base(repository)
        {

        }

        public override Task<List<Country>> AskAsync(FindAllCountries criterion, CancellationToken cancellationToken = default)
        {
            return Repository.GetAllAsync(cancellationToken);
        }
    }
}
