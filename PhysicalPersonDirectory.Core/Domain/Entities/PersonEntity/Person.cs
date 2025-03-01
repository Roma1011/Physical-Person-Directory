using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

internal class Person:Entity
{
//--------------------------------------------Initializer--------------------------------------------
    public Person(string pid, string name, string surname, TypeOfPhone? typeOfPhone, string? phoneNumber,Gender? gender,DateOfBirth dateOfPBirth, int? cityId)
    {
        Pid = pid;
        Name = name;
        Surname = surname;
        TypeOfPhone = typeOfPhone;
        PhoneNumber = phoneNumber;
        Gender = gender;
        DateOfPBirth = dateOfPBirth;
        CityId = cityId;
    }
//--------------------------------------------Properties--------------------------------------------
 
    public string Pid { get; private set; }
    public string Name { get; private set; }
    public string Surname { get;  private set; }
    public TypeOfPhone? TypeOfPhone { get;private set; }
    public string? PhoneNumber { get;private set; }
    public string? ImageSource { get;private set; }
    public Gender? Gender { get;private set; }
    public DateOfBirth DateOfPBirth { get;private set; }
    public int? CityId { get; private set; }
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public City? City { get; }
    // ReSharper disable once CollectionNeverUpdated.Global
    public ICollection<RelatedPerson> RelatedPersons { get; private set; } = new List<RelatedPerson>();

    // Relationships where this Person is the target
    public ICollection<RelatedPerson> RelatedToPersons { get; private set; } = new List<RelatedPerson>();
    
//--------------------------------------------Methods--------------------------------------------
    public string AppendImage(string contentType)
    {
        ImageSource = Guid.NewGuid()+"."+contentType.Substring(contentType.LastIndexOf('/')+1);
        return ImageSource;
    }
    
    public void UpdatePersonalInfo(string pid,string name, string surname, TypeOfPhone? typeOfPhone, string? phoneNumber, Gender? gender, DateOfBirth dateOfPBirth, int? cityId)
    {
        Pid = pid;
        Name = name;
        Surname = surname;
        TypeOfPhone = typeOfPhone;
        PhoneNumber = phoneNumber;
        Gender = gender;
        DateOfPBirth = dateOfPBirth;
        CityId = cityId;
    }
}