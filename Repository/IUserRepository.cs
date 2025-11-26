using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int id);
        User LoginUser(User loginUser);
        void UpdateUser(int id, User myUser);
    }
}