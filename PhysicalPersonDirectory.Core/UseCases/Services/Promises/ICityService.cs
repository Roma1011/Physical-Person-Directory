using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Promises;

public interface ICityService
{
    public Task<Result<string>> AddCityAsync(string cityName);
}