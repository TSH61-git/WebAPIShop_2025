using Entity;
using Repository;
namespace Service
{
    public class Service
    {

        private readonly Repository.Repository repository  = new Repository.Repository();

        public Users getUserByID(int id)
        {
            return repository.getUserByID(id);
        }

        public Users addUser(Users user)
        {
            return repository.addUser(user);
        }  

        public Users loginUser(LoginUsers loginUser)
        {
            return repository.loginUser(loginUser);
        }

        public void updateUser(int id, Users myUser)
        {
            repository.updateUser(id, myUser);
        }

    }
}
