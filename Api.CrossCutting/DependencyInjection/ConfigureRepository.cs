using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Api.Data.Context;
namespace Api.CrossCutting.DependencyInjection;

public class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {   
        string connectString = "server=localhost;userid=root;password=1234;database=costs;port=3307";
        serviceCollection.AddDbContext<AppDbContext> (
            options => options.UseMySql(connectString,ServerVersion.AutoDetect(connectString))
        );
    }
}
