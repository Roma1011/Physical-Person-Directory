using PhysicalPersonDirectory.Core.DAO.Context;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Implementation;

internal class PersonRepository:BaseRepository<Person,PhysicalPersonDbContext>,IPersonRepository
{
    public PersonRepository(PhysicalPersonDbContext dbContext) : base(dbContext) {}
}