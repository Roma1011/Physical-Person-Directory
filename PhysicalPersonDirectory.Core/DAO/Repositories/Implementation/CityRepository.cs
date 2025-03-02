using PhysicalPersonDirectory.Core.DAO.Context;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Implementation;

internal class CityRepository:BaseRepository<City,PhysicalPersonDbContext>,ICityRepository
{
    public CityRepository(PhysicalPersonDbContext dbContext) : base(dbContext) { }
}