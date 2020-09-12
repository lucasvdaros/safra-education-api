using AutoMapper;
using SafraEducacional.Domain.DTO.User;
using SafraEducacional.Domain.Entity;

namespace SafraEducacional.Infra.CrossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            // User
            CreateMap<UserDTO, User>();
        }
    }
}