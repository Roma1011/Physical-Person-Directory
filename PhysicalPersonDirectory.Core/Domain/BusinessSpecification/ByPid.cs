using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.Domain.BusinessSpecification;

internal class ByPid:BaseSpecification<Person>
{
    public ByPid(string pid)
      =>  base.Predicate = person => person.Pid == pid;
}