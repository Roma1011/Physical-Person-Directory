using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Request;

public class AddRelationPerson
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
    [SwaggerSchema(Description = "Gender: 1 = Colleague, 2 = Familiar, 3 = Relative, 4 = Other")]
    [Range(1, 4, ErrorMessage = "Relationship Type must be 1 (Colleague) , 2 (Familiar) , 3 (Relative) , 4 (Other)")]
    public int RelationType { get; set; }
}