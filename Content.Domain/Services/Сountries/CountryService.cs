using Commands.Builders.Abstractions;
using Content.Domain.Commands.Extensions;
using Content.Domain.Entities.Location;
using Content.Domain.Exceptions.LocationExceptions;
using Content.Domain.Queries.Criteria;
using Content.Domain.Queries.Extensions;
using Queries.Builders.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Domain.Services.Сountries
{
    public class CountryService : ICountryService
    {
        private readonly IAsyncCommandBuilder _commandBuilder;

        private readonly IAsyncQueryBuilder _queryBuilder;

        public CountryService(IAsyncCommandBuilder commandBuilder, IAsyncQueryBuilder queryBuilder)
        {
            _commandBuilder = commandBuilder ??
                throw new ArgumentNullException(nameof(commandBuilder));
            
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task<Country> CreateCountryAsync(string name, CancellationToken cancellationToken = default)
        {
            await CheckIsCountryByNameAsync(name, cancellationToken);

            var country = new Country(name);

            await _commandBuilder.CreateAsync(country, cancellationToken);

            return country;
        }

        public async Task EditCountryAsync(long id, string name, CancellationToken cancellationToken = default)
        {
            var country = await GetCountryByIdAsync(id, cancellationToken);

            country = new Country(name);
        }

        public async Task<List<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            return await _queryBuilder.For<List<Country>>()
                .WithAsync(new FindAllCountries(), cancellationToken);
        }

        public async Task<Country> GetCountryById(long id, CancellationToken cancellationToken = default)
        {
            return await GetCountryById(id, cancellationToken);
        }

        private async Task CheckIsCountryByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            _ = await _queryBuilder.For<Country>()
                .WithAsync(new FindCountryByName(name), cancellationToken) ??
                throw new LocationAlreadyExistsException("A country with this name already exists");
        }

        private async Task<Country> GetCountryByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _queryBuilder.FindByIdAsync<Country>(id, cancellationToken)
                ?? throw new LocationNotFoundException("Сountry not found");
        }
    }
}
