namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Response;

public class GetPerson
{
    public string Pid { get; set; }=null!;
    public string Name { get; set; }=null!;
    public string Surname { get; set; }=null!;
    public string? Gender { get; set; }
    public byte? GenderId { get; set; }
    public string? BirthDate { get; set; } = null!;
    public int? CityId { get; set; }
    public string? CityName { get; set; }
    public string? TypeOfPhone { get; set; }
    public byte? TypeOfPhoneId { get; set; }
    public string? PhoneNumber{ get; set; }
    
    public byte[]? Image { get; set; }
    
    public List<PersonOverhead> RelatedPersons { get; set; }=new();
}