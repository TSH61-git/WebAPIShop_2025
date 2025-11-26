using Entities;

namespace Service
{
    public interface IUserService
    {
        User AddUser(User user);
        User GetUserById(int id);
        User LoginUser(User loginUser);
        bool UpdateUser(int id, User user);
    }
}