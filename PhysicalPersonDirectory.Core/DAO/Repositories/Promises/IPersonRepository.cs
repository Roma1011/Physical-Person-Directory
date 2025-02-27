using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Promises;

internal interface IPersonRepository
{
    public Task<Person?> GetByIdAsync(int id);
    public Task<bool> IsExistByAnyAsync(BaseSpecification<Person> baseSpecification);
    public Task<EntityEntry> AddAsync(Person entity);
    public Task<EntityEntry> UpdateAsync(Person type);
    public Task<EntityEntry> DeleteAsync(Person type);
}