using System.Linq.Expressions;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Infra.Abstraction.Specification;

public abstract class BaseSpecification<T>where T:Entity
{
    public Expression<Func<T,bool>> Predicate { get; protected set; }
}