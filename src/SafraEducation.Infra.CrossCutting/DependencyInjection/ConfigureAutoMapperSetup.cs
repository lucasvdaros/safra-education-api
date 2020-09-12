using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SafraEducacional.Infra.CrossCutting.Mappings;

namespace SafraEducation.Infra.CrossCutting.DependencyInjection
{
    public static class ConfigureAutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToEntityProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}