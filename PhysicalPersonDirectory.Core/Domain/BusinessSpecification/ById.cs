using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.Domain.BusinessSpecification;

internal class ById:BaseSpecification<Person>
{
    public ById(int id)
        => Predicate = p => p.Id == id;
}