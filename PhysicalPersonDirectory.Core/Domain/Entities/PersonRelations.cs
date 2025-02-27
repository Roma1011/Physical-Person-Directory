using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities;

public class PersonRelations(int personId, int relatedPersonId) : Entity
{
    public int PersonId { get; internal set; } = personId;
    public int RelatedPersonId { get; internal set; } = relatedPersonId;
}