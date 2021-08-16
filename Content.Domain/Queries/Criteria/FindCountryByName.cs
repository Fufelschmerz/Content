using Queries.Criterions.Abstraction;

namespace Content.Domain.Queries.Criteria
{
    public record FindCountryByName(string Name) : ICriterion;
}
