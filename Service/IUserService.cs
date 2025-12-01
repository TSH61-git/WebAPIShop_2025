using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> AddUserasync(User user);
        Task<User> GetUserByIdasync(int id);
        Task<User> LoginUserasync(User loginUser);
        bool UpdateUserasync(int id, User user);
    }
}