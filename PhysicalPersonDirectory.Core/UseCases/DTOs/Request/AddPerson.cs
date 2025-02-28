using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Request;

public class AddPerson
{
    [Required]
    [MaxLength(12)]
    public string Pid { get; set; }=null!;
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }=null!;

    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }=null!;
    
    [SwaggerSchema(Description = "Gender: 1 = Male, 2 = Female")]
    [Range(1, 2, ErrorMessage = "Gender Type must be 1 (Male) or 2 (Female)")]
    public byte? Gender { get; set; }
    
    [Required]
    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "BirthDate must be in the format yyyy-MM-dd.")]
    public string BirthDate { get; set; } = null!;
    
    public int? CityId { get; set; }
    [SwaggerSchema(Description = "Gender: 1 = Mobile, 2 = OfficePhone, 3 = HousePhone")]
    [Range(1, 3, ErrorMessage = "Phone Type must be 1 (Mobile), 2 (OfficePhone), or 3 (HousePhone)")]
    public int? TypeOfPhone { get; set; }
    public string? PhoneNumber{ get; set; }
}