using Queries.Criterions.Abstraction;

namespace Content.Domain.Queries.Criteria
{
    public record FindById(long Id) : ICriterion;
}
