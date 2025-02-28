namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Request;

public class RemoveRelationPerson
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
}