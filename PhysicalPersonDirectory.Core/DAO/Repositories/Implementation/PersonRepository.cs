using Microsoft.EntityFrameworkCore;
using PhysicalPersonDirectory.Core.DAO.Context;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Implementation;

internal class PersonRepository:BaseRepository<Person,PhysicalPersonDbContext>,IPersonRepository
{
    public PersonRepository(PhysicalPersonDbContext dbContext) : base(dbContext) {}

    public async Task<List<Person>> GetAllMatchedPersonBySpecificationAsync(BaseSpecification<Person> baseSpecification)
    {
        var query=await base.GetAllAsync();
        query = query.Where(baseSpecification.Predicate);
        
        if (baseSpecification.Skip.HasValue)
        {
            query = query.Skip(baseSpecification.Skip.Value);
        }
        if (baseSpecification.Take.HasValue)
        {
            query = query.Take(baseSpecification.Take.Value);
        }
        return await query.ToListAsync();
    }

    public async Task<List<Person>> GetAllPersonBySpecificationAsync(BaseSpecification<Person>baseSpecification)
    {
         var result=await base.GetAllAsync();
         return await result.Where(baseSpecification.Predicate).ToListAsync();
    }

    public Task<Person?> GetPersonByAggregatedAsync(int id)
    {
        return base.DbContext.Person
            .Include(x => x.City)
            .Include(x => x.RelatedPersons) 
            .ThenInclude(x => x.Related) 
            .Include(x => x.RelatedToPersons)
            .ThenInclude(x => x.Person) 
            .SingleOrDefaultAsync(x => x.Id == id); 
    }
    
}