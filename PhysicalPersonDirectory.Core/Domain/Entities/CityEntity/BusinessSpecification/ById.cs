using PhysicalPersonDirectory.Infra.Abstraction.Specification;

namespace PhysicalPersonDirectory.Core.Domain.Entities.CityEntity.BusinessSpecification;

internal class ByCityName:BaseSpecification<City>
{
    public ByCityName(string cityName)
        => Predicate = c => c.Name.ToLower() == cityName.ToLower();
}