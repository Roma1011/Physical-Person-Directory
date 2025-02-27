using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

internal class Person:Entity
{
    public string Pid { get; internal set; }=null!;
    public string Name { get; internal set; }=null!;
    public string Surname { get; internal set; }=null!;
    public TypeOfPhone? TypeOfPhone { get;internal set; }
    public string? PhoneNumber { get;internal set; }
    public string? ImagePath { get;internal set; }
    public Gender Gender { get;internal set; }
    public DateOnly DateOfPBirth { get;internal set; }
    public int? CityId { get; internal set; }
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public City? City { get; }
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<PersonRelation> PersonRelations { get; } = new();
}