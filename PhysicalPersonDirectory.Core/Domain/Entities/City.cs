using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.Domain.Entities;

internal class City:Entity
{
    public string Name { get; internal set; }=null!;
    public Person Person { get;}
}