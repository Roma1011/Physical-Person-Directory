using System.Linq.Expressions;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.Domain.BusinessSpecification;

internal class BySearch : BaseSpecification<Person>
{
    public BySearch(string searchTerm,bool isDeepSearch,int pageNumber,int pageSize)
    {
        Expression<Func<Person,bool>> quickSearch = per => per.Name.ToLower().Contains(searchTerm) || per.Surname.ToLower().Contains(searchTerm) || per.Pid.ToLower().Contains(searchTerm);
        Expression<Func<Person,bool>> deepSearch = per => per.Name.ToLower().Contains(searchTerm) || per.Surname.ToLower().Contains(searchTerm) || per.Pid.ToLower().Contains(searchTerm)|| per.PhoneNumber.ToLower().Contains(searchTerm);
        if (!string.IsNullOrEmpty(searchTerm))
        {
            Predicate = quickSearch;
            
            if (isDeepSearch)
                Predicate = deepSearch;

            WithPaging(pageNumber, pageSize);
        }
    }
}