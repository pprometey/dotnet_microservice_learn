using CommandsService.Models;
using CommandsService.SyncDataService.Grpc;

namespace CommandsService.Data;

public static class PerpDb
{
    public static void PerpPopulation(IApplicationBuilder applicationBuilder)
    {
        using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();

            var platforms = grpcClient?.ReturnAllPlatform();

            var repo = serviceScope.ServiceProvider.GetService<ICommandRepo>();
            
            if (repo is not null && platforms is not null) SeedData(repo, platforms);
        }
    }

    private static void SeedData(ICommandRepo repo, IEnumerable<Platform> platforms)
    {
        Console.WriteLine("--> Seeding new platforms...");

        foreach (var platform in platforms)
        {
            if(!repo.ExternalPlatformExist(platform.ExternalId))
            {
                repo.CreatePlatform(platform);
            }
            repo.SaveChanges();
        }
    }
}