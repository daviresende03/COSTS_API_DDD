using Microsoft.Extensions.DependencyInjection;
using Api.Service.Services;
using Api.Domain.Interfaces;
namespace Api.CrossCutting.DependencyInjection;

public class ConfigureService
{
    public static void ConfigureDependenciesService (IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProject, ProjectService>();
        serviceCollection.AddScoped<ICategory, CategoryService>();
    }
}
