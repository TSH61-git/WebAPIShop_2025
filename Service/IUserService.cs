using Entities;

namespace Service
{
    public interface IUserService
    {
        Users AddUser(Users user);
        Users GetUserById(int id);
        Users LoginUser(Users loginUser);
        bool UpdateUser(int id, Users user);
    }
}