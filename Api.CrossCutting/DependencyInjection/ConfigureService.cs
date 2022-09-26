using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService (IServiceCollection serviceCollection)
        {
            builder.Services.AddScoped<IProject, ProjectService>();
            builder.Services.AddScoped<ICategory, CategoryService>();
        }
    }
}
