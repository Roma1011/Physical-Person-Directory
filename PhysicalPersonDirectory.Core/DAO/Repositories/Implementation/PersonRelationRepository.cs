using PhysicalPersonDirectory.Core.DAO.Context;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Implementation;

internal class PersonRelationRepository:BaseRepository<RelatedPerson,PhysicalPersonDbContext>,IPersonRelationRepository
{
    public PersonRelationRepository(PhysicalPersonDbContext dbContext) : base(dbContext) {}
}