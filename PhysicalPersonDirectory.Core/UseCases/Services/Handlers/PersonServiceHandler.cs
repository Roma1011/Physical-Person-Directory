using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.BusinessSpecification;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Core.UseCases.Services.Promises;
using PhysicalPersonDirectory.Infra.Abstraction.Common;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Handlers;

internal class PersonServiceHandler(IPersonRepository personRepository,IUnitOfWork uow):IPersonService
{
    public async Task<Result<bool>> AddPersonAsync(AddPerson addRequest)
    {
        if (await personRepository.IsExistByAnyAsync(new ByPid(addRequest.Pid)))
            return new Result<bool>(false,false,"Person already exists",409);
        
        Result<DateOfBirth> dateOfBirth = DateOfBirth.InitDateOfBirth(addRequest.BirthDate);
        if(dateOfBirth.IsSuccess == false)
            return new Result<bool>(false,false,dateOfBirth.ErrorMessage,400);
        
        Person person = new Person(addRequest.Pid, addRequest.Name, addRequest.Surname,
            (TypeOfPhone?)addRequest.TypeOfPhone, addRequest.PhoneNumber, (Gender?)addRequest.Gender,dateOfBirth.Value!,addRequest.CityId);
        
        EntityEntry entry=await personRepository.AddAsync(person);
        await uow.SaveChangesAsync();
        return new Result<bool>(true, false,null,201);
    }

    public async Task<Result<bool>> AppendPhotoAsync(AppendImage appendImage)
    {
        var fileRepository = new FileRepository();
        Person? person=await personRepository.GetByIdAsync(appendImage.PersonId);
        if (person is null)
            return new Result<bool>(false,false,"Person not found",404);

        var source=person.AppendImage(appendImage.File.ContentType);
        bool isWrote=await fileRepository.Save(appendImage.File.OpenReadStream(),source);
        if (isWrote == false)
            return new Result<bool>(false,false,"File not saved",500);
        
        EntityEntry entry=await personRepository.UpdateAsync(person);
        if (entry.State!=EntityState.Modified)
            return new Result<bool>(false,false,null,500);
        
        await uow.SaveChangesAsync();
        return new Result<bool>(true,false,null,200);
    }
}