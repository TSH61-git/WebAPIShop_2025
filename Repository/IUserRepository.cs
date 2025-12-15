using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> LoginUser(User loginUser);
        Task UpdateUser(int id, User myUser);
    }
}