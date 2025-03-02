using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.BusinessSpecification;

internal class ByPid:BaseSpecification<Person>
{
    public ByPid(string pid)
      =>  base.Predicate = person => person.Pid == pid;
}