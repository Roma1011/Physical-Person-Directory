using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Promises;

internal interface IPersonRepository
{
    public Task<List<Person>> GetAllMatchedPersonBySpecificationAsync(BaseSpecification<Person> baseSpecification);
    public Task<List<Person>> GetAllPersonBySpecificationAsync(BaseSpecification<Person> baseSpecification);
    public Task<Person?> GetPersonByAggregatedAsync(int id);
    public Task<Person?> GetByIdAsync(int id);
    public Task<int> IsExistWithCountAsync(BaseSpecification<Person> baseSpecification);
    public Task<EntityEntry> AddAsync(Person entity);
    public Task<EntityEntry> UpdateAsync(Person type);
    public Task<EntityEntry> DeleteAsync(Person type);
}