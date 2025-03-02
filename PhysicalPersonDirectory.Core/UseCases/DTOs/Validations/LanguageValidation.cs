using System.ComponentModel.DataAnnotations;

namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Validations;

public class LanguageValidation:ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
            return false;
        
        bool hasUnicode = value.ToString()!.All(ch => ch > 127);
        bool isAsciiOnly = value.ToString()!.All(ch => ch <= 127);
        return hasUnicode | isAsciiOnly;
    }

    public override string FormatErrorMessage(string name)
    {
        return "The text is not formatted correctly.";
    }
}