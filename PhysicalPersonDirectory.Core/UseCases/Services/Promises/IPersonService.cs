using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Promises;

public interface IPersonService
{
    public Task<Result<bool>> AddPersonAsync(AddPerson addPerson);
    public Task<Result<bool>> AppendPhotoAsync(AppendImage appendImage);
    public Task<Result<bool>> AddRelationPersonAsync(AddRelationPerson updatePerson);
    public Task<Result<bool>> RemoveRelationPersonAsync(RemoveRelationPerson relationPerson);

    public Task<Result<bool>> UpdatePersonAsync(UpdatePerson addRelationPerson);

}