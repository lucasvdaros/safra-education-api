using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafraEducacional.Domain.Entity;
using SafraEducation.Domain.Interface.Repository;
using SafraEducation.Infra.Data;

namespace SafraEducacional.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<User> GetByLogin(string login)
        {
            // Como seria feito
            //return await dbSet.FirstOrDefaultAsync(u => u.Email.Equals(login));
            
            if(login.Equals("safra@gmail.com"))
            {
                // mockando para demonstrar para demonstrar
            var user = new User();
            user.Email = "safra@gmail.com";
            user.PasswordDigest = "10000.i0wt/ndvvw0/T/Kop2S99A==.Uv33Y1sHv+QO05qdqvbKEg3A9pGkQqhvTiB3BRf69BA="; // hash de: senhalegal
            user.Name = "Dêm uma moral pra gente";

            return user;
            }
            else
            {
                return null;
            }            
        }
    }
}