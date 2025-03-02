using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Core.UseCases.DTOs.Response;
using PhysicalPersonDirectory.Infra.Abstraction.Common;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Promises;

public interface IPersonService
{
    public Task<Result<List<PersonOverhead>>> SearchPersonAsync(string searchTerm, bool isDeepSearch,int pageNumber = 1, int pageSize = 10);
    public Task<Result<GetPerson>> GetPersonByIdAsync(int id);
    public Task<Result<bool>> AddPersonAsync(AddPerson addPerson);
    public Task<Result<bool>> AppendPhotoAsync(AppendImage appendImage);
    public Task<Result<bool>> AddRelationPersonAsync(AddRelationPerson updatePerson);
    public Task<Result<bool>> UpdatePersonAsync(UpdatePerson addRelationPerson);
    public Task<Result<bool>> RemoveRelationPersonAsync(RemoveRelationPerson relationPerson);
    public Task<Result<bool>> RemovePersonAsync(int id);
}