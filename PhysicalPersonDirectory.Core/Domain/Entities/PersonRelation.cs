using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities;

internal class PersonRelation(int personId, int relatedPersonId) : Entity
{
    public int PersonId { get; internal set; } = personId;
    public Person Person { get;} = null!;
    
    public int RelatedPersonId { get; internal set; } = relatedPersonId;
    public Person RelatedPerson { get;} = null!;
}
