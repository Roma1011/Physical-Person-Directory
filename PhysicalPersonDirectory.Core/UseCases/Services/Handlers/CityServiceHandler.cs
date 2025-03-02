using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Core.Domain.Entities.CityEntity.BusinessSpecification;
using PhysicalPersonDirectory.Core.UseCases.Services.Promises;
using PhysicalPersonDirectory.Infra.Abstraction.Common;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.UseCases.Services.Handlers;

internal class CityServiceHandler(ICityRepository cityRepository,IUnitOfWork uow):ICityService
{
    public async Task<Result<string>> AddCityAsync(string cityName)
    {
        if (await cityRepository.IsExistWithCountAsync(new ByCityName(cityName)) > 0)
            return new Result<string>(false, cityName, "city already exist", 409);
        
        EntityEntry entry=await cityRepository.AddAsync(new City(cityName));
        if (entry.State!=EntityState.Added)
            return new Result<string>(false,cityName,null,500);

        await uow.SaveChangesAsync();
        return new Result<string>(true,cityName,null,201);
    }
}