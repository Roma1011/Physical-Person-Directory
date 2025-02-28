using Microsoft.EntityFrameworkCore;
using PhysicalPersonDirectory.Core.DAO.Context;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Implementation;

internal class PersonRepository:BaseRepository<Person,PhysicalPersonDbContext>,IPersonRepository
{
    public PersonRepository(PhysicalPersonDbContext dbContext) : base(dbContext) {}

    public Task<Person?> GetPersonByAggregatedAsync(int id)
    {
        return base.DbContext.Person
            .Include(x => x.City)
            .Include(x => x.RelatedPersons)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}