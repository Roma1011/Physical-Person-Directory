using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities;

internal class Person:Entity
{
    public string Pid { get; internal set; }=null!;
    public string Name { get; internal set; }=null!;
    public string Surname { get; internal set; }=null!;
    public string PhoneNumber { get;internal set; }=null!;
    public string Gender { get;internal set; }=null!;
    public DateTime BirthDate { get;internal set; }
    
}