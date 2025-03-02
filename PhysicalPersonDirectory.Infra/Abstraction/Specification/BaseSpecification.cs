using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

[assembly:InternalsVisibleTo("PhysicalPersonDirectory.Core")]

namespace PhysicalPersonDirectory.Infra.Abstraction.Specification;
internal abstract class BaseSpecification<T>where T:Entity
{
    public Expression<Func<T,bool>> Predicate { get; protected set; }
    public int? Skip { get; protected set; }
    public int? Take { get; protected set; }

    public BaseSpecification<T> WithPaging(int pageNumber, int pageSize)
    {
        Skip = (pageNumber - 1) * pageSize;
        Take = pageSize;
        return this;
    }
}