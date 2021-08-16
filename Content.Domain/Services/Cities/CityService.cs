using System;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Domain.Services.Cities
{
    public class CityService : ICityService
    {
        public Task CityEditAsync(long id, string name, long countryId)
        {
            throw new NotImplementedException();
        }

        public Task CreateCityAsync(string name, long countryId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task GetCityAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task GetCityListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
