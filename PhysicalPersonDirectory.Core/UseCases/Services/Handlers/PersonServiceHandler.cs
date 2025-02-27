using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Core.UseCases.Services.Promises;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Handlers;

internal class PersonServiceHandler:IPersonService
{
    public Task<Result> AddPersonAsync(AddPerson person)
    {
        throw new NotImplementedException();
    }
}