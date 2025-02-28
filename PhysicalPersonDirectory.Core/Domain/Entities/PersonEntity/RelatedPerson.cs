using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

internal class RelatedPerson(int personId, int relatedPersonId,RelationType relationType) : Entity
{
    public int PersonId { get; private set; } = personId;
    public Person Person { get;} = null!;
    
    public int RelatedPersonId { get; private set; } = relatedPersonId;
    public Person Related { get;} = null!;
    
    public RelationType RelationType { get; private set; } = relationType;
}
