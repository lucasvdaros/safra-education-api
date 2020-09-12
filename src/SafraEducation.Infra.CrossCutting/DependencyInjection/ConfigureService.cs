using Microsoft.Extensions.DependencyInjection;
using SafraEducacional.Domain.Interface.Service;
using SafraEducacional.Services;

namespace SafraEducation.Infra.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IPasswordHasherService, PasswordHasherService>();
        }
    }
}