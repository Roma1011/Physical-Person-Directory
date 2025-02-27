using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Promises;

internal interface IPersonRepository
{
    public Task<bool> IsExistByAnyAsync(BaseSpecification<Person> baseSpecification);
}