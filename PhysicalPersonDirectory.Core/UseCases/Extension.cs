using Microsoft.Extensions.DependencyInjection;
using PhysicalPersonDirectory.Core.UseCases.Services.Handlers;
using PhysicalPersonDirectory.Core.UseCases.Services.Promises;

namespace PhysicalPersonDirectory.Core.UseCases;

public static class Extension
{
    public static IServiceCollection AddUseCases(this IServiceCollection collection)
    {
        collection.AddScoped<IPersonService, PersonServiceHandler>();
        return collection;
    }
}