using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities;

internal class RelatedPerson(int personId, int relatedPersonId) : Entity
{
    public int PersonId { get; private set; } = personId;
    public Person Person { get;} = null!;
    
    public int RelatedPersonId { get; private set; } = relatedPersonId;
    public Person Related { get;} = null!;
}
