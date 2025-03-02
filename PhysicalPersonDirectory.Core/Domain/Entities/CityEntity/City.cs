using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities;

internal class City:Entity
{
    public City(string name)
    {
        Name = name;
    }
    public string Name { get; private set; }=null!;
    public Person Person { get;}
}