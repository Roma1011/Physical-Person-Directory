using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Promises;

public interface IPersonService
{
    public Task<Result> AddPersonAsync(AddPerson person);
}