using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using PhysicalPersonDirectory.Core.DAO;

[assembly:InternalsVisibleTo("PhysicalPersonDirectory.Api")]
namespace PhysicalPersonDirectory.Core;

public static class Extension
{
    public static IServiceCollection AddCore(this IServiceCollection collection)
    {
        collection.AddDatabaseInfrastructure();
        return collection;
    }
}