using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhysicalPersonDirectory.Core.DAO.Context;
using PhysicalPersonDirectory.Core.DAO.Repositories.Implementation;
using PhysicalPersonDirectory.Core.DAO.Repositories.Promises;
using PhysicalPersonDirectory.Infra.Persistence.DAL;

namespace PhysicalPersonDirectory.Core.DAO;

internal static class Extension
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection collection)
    {
        collection.AddDbContext<PhysicalPersonDbContext>(context =>
        {
            context.UseSqlServer("Data Source=IT-RKEKUA\\SQLEXPRESS;Initial Catalog=PhysicalPersonDb;Trusted_Connection=True;Encrypt=False;");
        });
        collection.AddScoped<IPersonRepository, PersonRepository>();
        collection.AddScoped<IUnitOfWork>(unit => unit.GetRequiredService<PhysicalPersonDbContext>());
        return collection;
    }
}