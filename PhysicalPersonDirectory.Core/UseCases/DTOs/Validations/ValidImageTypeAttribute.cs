using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Request;

public class ValidImageTypeAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is IFormFile file)
        {
            string contentType = file.ContentType.ToLower();
            return contentType == "image/jpeg" || contentType == "image/png";
        }
        return false;
    }
    public override string FormatErrorMessage(string name)
    {
        return $"The file type must be either jpeg or png.";
    }
}