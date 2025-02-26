using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities;

public class PersonRelations:Entity
{
    public PersonRelations(int personId, int relatedPersonId)
    {
        PersonId = personId;
        RelatedPersonId = relatedPersonId;
    }
    public int PersonId { get; internal set; }
    public int RelatedPersonId { get; internal set; }
}