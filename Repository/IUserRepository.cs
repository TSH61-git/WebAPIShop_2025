using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Users AddUser(Users user);
        Users GetUserById(int id);
        Users LoginUser(Users loginUser);
        void UpdateUser(int id, Users myUser);
    }
}