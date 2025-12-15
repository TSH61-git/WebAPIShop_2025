using Entities;
using Repository.Models;

namespace Service
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> LoginUser(User loginUser);
        Task<bool> UpdateUser(int id, User user);
    }
}