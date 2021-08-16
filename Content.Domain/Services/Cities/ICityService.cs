using Domain.Services.Abstraction;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Domain.Services.Cities
{
    public interface ICityService : IDomainService
    {
        Task CreateCityAsync(string name, long countryId, CancellationToken cancellationToken = default);

        Task CityEditAsync(long id, string name, long countryId);

        Task GetCityAsync(long id);

        Task GetCityListAsync();
    }
}
