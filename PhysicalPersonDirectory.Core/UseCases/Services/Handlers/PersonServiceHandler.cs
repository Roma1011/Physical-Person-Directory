using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.BusinessSpecification;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;
using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Core.UseCases.DTOs.Response;
using PhysicalPersonDirectory.Core.UseCases.Services.Promises;
using PhysicalPersonDirectory.Infra.Abstraction.Common;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Handlers;

internal class PersonServiceHandler(IPersonRepository personRepository,IPersonRelationRepository personRelationRepository,IUnitOfWork uow)
    :IPersonService
{
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public async Task<Result<List<PersonOverhead>>> SearchPersonAsync(string searchTerm, bool isDeepSearch,int pageNumber = 1, int pageSize = 10)
    {
        var searchResult=await personRepository.GetAllMatchedPersonBySpecificationAsync(new BySearch(searchTerm,isDeepSearch,pageNumber,pageSize));
        var personOverhead=searchResult.Select(per => new PersonOverhead
        {
            Id = per.Id,
            Pid = per.Pid,
            Name = per.Name,
            Surname = per.Surname
        }).ToList();
        return new Result<List<PersonOverhead>>(true, personOverhead, null, 200);
    }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public async Task<Result<GetPerson>> GetPersonByIdAsync(int id)
    {
        Person? person =await personRepository.GetPersonByAggregatedAsync(id);
        if (person is null)
            return new Result<GetPerson>(false,null,"Person not found",404);
        
        PersonImageRepository personImageRepository = new PersonImageRepository();
        byte[]?image=await personImageRepository.GetAsync(person.ImageSource);
        
        GetPerson getPerson = new GetPerson
        {
            Pid = person.Pid,
            Name = person.Name,
            Surname = person.Surname,
            Gender = person.Gender.ToString(),
            GenderId = (byte?)person.Gender,
            BirthDate = person.DateOfPBirth.Value.ToString("yyyy-MM-dd"),
            TypeOfPhone = person.TypeOfPhone.ToString(),
            TypeOfPhoneId = (byte?)person.TypeOfPhone,
            PhoneNumber = person.PhoneNumber,
            Image = image,
            RelatedPersons = person.RelatedPersons.Any() ? 
                person.RelatedPersons.Select(x => new PersonOverhead
                {
                    Id = x.RelatedPersonId,
                    Pid = x.Related.Pid,
                    Name = x.Related.Name,
                    Surname = x.Related.Surname
                }).ToList() :  
                person.RelatedToPersons.Select(x => new PersonOverhead
                {
                    Id = x.PersonId,
                    Pid = x.Person.Pid,
                    Name = x.Person.Name,
                    Surname = x.Person.Surname
                }).ToList()
        };
        
        return new Result<GetPerson>(true,getPerson,null,200);
    }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public async Task<Result<bool>> AppendPhotoAsync(AppendImage appendImage)
    {
        var fileRepository = new PersonImageRepository();
        Person? person=await personRepository.GetByIdAsync(appendImage.PersonId);
        if (person is null)
            return new Result<bool>(false,false,"Person not found",404);

        var source=person.AppendImage(appendImage.Image.ContentType);
        bool isWrote=await fileRepository.Save(appendImage.Image.OpenReadStream(),source);
        if (isWrote == false)
            return new Result<bool>(false,false,"File not saved",500);
        
        EntityEntry entry=await personRepository.UpdateAsync(person);
        if (entry.State!=EntityState.Modified)
            return new Result<bool>(false,false,null,500);
        
        await uow.SaveChangesAsync();
        return new Result<bool>(true,false,null,200);
    }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public async Task<Result<bool>> AddRelationPersonAsync(AddRelationPerson relationPerson)
    {
        Person? person=await personRepository.GetPersonByAggregatedAsync(relationPerson.PersonId);
        if (person is null)
            return new Result<bool>(false,false,"Person not found",404);
        
        if(person.RelatedPersons.Any(x => x.RelatedPersonId == relationPerson.RelatedPersonId))
            return new Result<bool>(false,false,"Relation already exists",409);
        
        if(relationPerson.PersonId == relationPerson.RelatedPersonId)
            return new Result<bool>(false,false,"Person and related person can not be same",400);
        
        person.RelatedPersons.Add(new RelatedPerson(relationPerson.PersonId,relationPerson.RelatedPersonId,(RelationType)relationPerson.RelationType));
        EntityEntry entry=await personRepository.UpdateAsync(person);
        if (entry.State!=EntityState.Modified)
            return new Result<bool>(false,false,null,500);
        
        await uow.SaveChangesAsync();
        return new Result<bool>(true,false,null,200);
    }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
  //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
    public async Task<Result<bool>> RemovePersonAsync(int id)
    {
        Person? person=await personRepository.GetByIdAsync(id);
        if (person is null)
            return new Result<bool>(false,false,"Person not found",404);
        
        EntityEntry entry=await personRepository.DeleteAsync(person);
        if (entry.State!=EntityState.Deleted)
            return new Result<bool>(false,false,null,500);
        
        await uow.SaveChangesAsync();
        return new Result<bool>(true,false,null,200);
    }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}