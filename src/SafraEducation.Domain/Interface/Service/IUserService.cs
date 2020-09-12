using System.Threading.Tasks;
using SafraEducacional.Domain.DTO.Login;
using SafraEducacional.Domain.DTO.User;

namespace SafraEducacional.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<LoginAccessDTO> Login(LoginDTO credentials);

        bool Authenticate(string passwordStored, string passwordInputed);        
    }
}