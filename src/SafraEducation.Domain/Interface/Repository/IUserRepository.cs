using System.Threading.Tasks;
using SafraEducacional.Domain.Entity;
using SafraEducacional.Domain.Interface.Repository;

namespace SafraEducation.Domain.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string login);        
    }
}