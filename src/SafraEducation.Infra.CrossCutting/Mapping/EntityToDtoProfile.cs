using AutoMapper;
using SafraEducacional.Domain.DTO.User;
using SafraEducacional.Domain.Entity;

namespace SafraEducacional.Infra.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            // User
            CreateMap<User, UserDTO>();
        }
    }
}