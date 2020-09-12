using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafraEducacional.Domain.Interface.Repository;
using SafraEducacional.Infra.Data.Repository;
using SafraEducation.Domain.Interface.Repository;
using SafraEducation.Infra.Data;

namespace SafraEducation.Infra.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<Context>(
                options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"))
            );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}