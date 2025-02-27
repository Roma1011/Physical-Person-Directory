using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

internal class Person:Entity
{
    public string Pid { get; private set; }=null!;
    public string Name { get; private set; }=null!;
    public string Surname { get;  private set; }=null!;
    public TypeOfPhone? TypeOfPhone { get;private set; }
    public string? PhoneNumber { get;private set; }
    public Uri? ImageSource { get;private set; }
    public Gender Gender { get;private set; }
    public DateOnly DateOfPBirth { get;private set; }
    public int? CityId { get; private set; }
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public City? City { get; }
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<RelatedPerson> RelatedPersons { get; } = new();
}