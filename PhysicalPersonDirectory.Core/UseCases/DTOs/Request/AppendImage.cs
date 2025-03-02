using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Request;

public class AppendImage
{
    [Required]
    [ValidImageType]
    public IFormFile Image { get; set; }
    [Required]
    public int PersonId { get; set; }
}