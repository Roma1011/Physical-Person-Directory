using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Promises;

internal interface ICityRepository
{
      public Task<int> IsExistWithCountAsync(BaseSpecification<City> baseSpecification);
      public Task<EntityEntry> AddAsync(City city);
}