using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUserasync(User user);
        Task<User> GetUserByIdasync(int id);
        Task<User> LoginUserasync(User loginUser);
        Task UpdateUserasync(int id, User myUser);
    }
}