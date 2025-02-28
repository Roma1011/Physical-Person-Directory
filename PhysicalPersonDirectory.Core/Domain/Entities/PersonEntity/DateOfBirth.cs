using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

public class DateOfBirth
{
    public DateOnly Value { get; init; }

    public static Result<DateOfBirth> InitDateOfBirth(string dateTime)
    {
        DateTime personRequest = Convert.ToDateTime(dateTime);
        DateOnly personBirthDate = new(personRequest.Year, personRequest.Month, personRequest.Day);
        DateOnly validateDate18Year = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        
        if(personBirthDate < validateDate18Year.AddYears(personBirthDate.Year - validateDate18Year.Year))
        {
            return new Result<DateOfBirth>(false,null,"Person must be at least 18 years old.",400);
        }
        return new Result<DateOfBirth>(true,new DateOfBirth(personBirthDate),null,200);
    }
    

    public DateOfBirth(DateOnly dateOnly)
    {
        this.Value = dateOnly;
    }
}