using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Users addUser(Users user);
        Users getUserByID(int id);
        Users loginUser(Users loginUser);
        void updateUser(int id, Users myUser);
    }
}