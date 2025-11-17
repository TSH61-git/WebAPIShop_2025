using Entities;

namespace Service
{
    public interface IUserService
    {
        Users addUser(Users user);
        Users getUserByID(int id);
        Users loginUser(Users loginUser);
        bool updateUser(int id, Users user);
    }
}