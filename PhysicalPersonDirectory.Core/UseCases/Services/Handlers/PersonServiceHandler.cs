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

internal class PersonServiceHandler(IPersonRepository personRepository,IPersonRelationRepository personRelationRepository,ICityRepository cityRepository,IUnitOfWork uow)
    :IPersonService
{
    public async Task<Result<bool>> AddPersonAsync(AddPerson addPerson)
    {
        if (await personRepository.IsExistWithCountAsync(new ByPid(addPerson.Pid)) > 0)
            return new Result<bool>(false,false,"Person already exists",409);
        
        Result<DateOfBirth> dateOfBirth = DateOfBirth.InitDateOfBirth(addPerson.BirthDate);
        if(dateOfBirth.IsSuccess == false)
            return new Result<bool>(false,false,dateOfBirth.ErrorMessage,400);
        
        Person person = new Person(addPerson.Pid, addPerson.Name, addPerson.Surname,
            (TypeOfPhone?)addPerson.TypeOfPhone, addPerson.PhoneNumber, (Gender?)addPerson.Gender,dateOfBirth.Value!,addPerson.CityId);
        
        EntityEntry entry=await personRepository.AddAsync(person);
        if (entry.State!=EntityState.Added)
            return new Result<bool>(false,false,null,500);
        
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

    public async Task<Result<bool>> AddRelationPersonAsync(AddRelationPerson relationPerson)
    {
        Person? person=await personRepository.GetPersonByAggregatedAsync(relationPerson.PersonId);
        if (person is null)
            return new Result<bool>(false,false,"Person not found",404);
        
        if(person.RelatedPersons.Any(x => x.RelatedPersonId == relationPerson.RelatedPersonId))
            return new Result<bool>(false,false,"Relation already exists",409);
        
        person.RelatedPersons.Add(new RelatedPerson(relationPerson.PersonId,relationPerson.RelatedPersonId,(RelationType)relationPerson.RelationType));
        EntityEntry entry=await personRepository.UpdateAsync(person);
        if (entry.State!=EntityState.Modified)
            return new Result<bool>(false,false,null,500);
        
        await uow.SaveChangesAsync();
        return new Result<bool>(true,false,null,200);
    }
    public async Task<Result<bool>> RemoveRelationPersonAsync(RemoveRelationPerson relationPerson)
    {
        Person? person=await personRepository.GetPersonByAggregatedAsync(relationPerson.PersonId);
        if (person is null)
            return new Result<bool>(false,false,"Person not found",404);
        
        if(person.RelatedPersons.Any(x => x.RelatedPersonId != relationPerson.RelatedPersonId && x.PersonId != relationPerson.PersonId))
            return new Result<bool>(false,false,"Relation not found",404);
        
        await personRelationRepository.DeleteAsync(person.RelatedPersons.First(x => x.RelatedPersonId == relationPerson.RelatedPersonId && x.PersonId == relationPerson.PersonId));
        await uow.SaveChangesAsync();
        return new Result<bool>(true,false,null,200);
    }

    public async Task<Result<bool>> UpdatePersonAsync(UpdatePerson updatePerson)
    {
        if (await personRepository.IsExistWithCountAsync(new ByPid(updatePerson.Pid)) > 1)
            return new Result<bool>(false,false,"Person already exists",409);
        
        Person? person=await personRepository.GetByIdAsync(updatePerson.Id);
        if (person is null)
            return new Result<bool>(false,false,"Person not found",404);
        
        {
            person.UpdatePersonalInfo(updatePerson.Pid,
                updatePerson.Name,updatePerson.Surname,
                (TypeOfPhone?)updatePerson.TypeOfPhone,
                updatePerson.PhoneNumber,
                (Gender)updatePerson.Gender!,
                DateOfBirth.InitDateOfBirth(updatePerson.BirthDate).Value!,
                updatePerson.CityId);
        }
        EntityEntry entry=await personRepository.UpdateAsync(person);
        if (entry.State!=EntityState.Modified)
            return new Result<bool>(false,false,null,500);
        
        await uow.SaveChangesAsync();
        return new Result<bool>(true,false,null,200);
    }
}