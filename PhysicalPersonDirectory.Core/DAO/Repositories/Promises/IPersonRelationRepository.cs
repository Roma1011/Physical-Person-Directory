using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

namespace PhysicalPersonDirectory.Core.DAO.Repositories.Promises;

internal interface IPersonRelationRepository
{
    public Task<EntityEntry> DeleteAsync(RelatedPerson relatedPerson);
}