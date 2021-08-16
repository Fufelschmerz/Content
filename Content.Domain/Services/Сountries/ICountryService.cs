using Content.Domain.Entities.Location;
using Domain.Services.Abstraction;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Domain.Services.Сountries
{
    public interface ICountryService : IDomainService 
    {
        Task<Country> CreateCountryAsync(string name, CancellationToken cancellationToken = default);

        Task<Country> GetCountryById(long id, CancellationToken cancellationToken = default);

        Task<List<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default);
    }
}
