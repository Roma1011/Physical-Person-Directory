namespace PhysicalPersonDirectory.Core.UseCases.DTOs.Response;

public class PersonOverhead
{
    public int Id { get; set; }
    public string Pid { get; set; }=null!;
    public string Name { get; set; }=null!;
    public string Surname { get; set; }=null!;
}