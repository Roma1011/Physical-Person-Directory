using Microsoft.AspNetCore.Http;
using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Promises;

public interface IPersonService
{
    public Task<Result<bool>> AddPersonAsync(AddPerson addRequest);
    public Task<Result<bool>> AppendPhotoAsync(AppendImage appendImage);
}