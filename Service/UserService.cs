using Entities;
using Repository;
using Zxcvbn;

namespace Service
{
    public class UserService
    {

        private readonly Repository.UserRepository repository  = new Repository.UserRepository();

        public Users getUserByID(int id)
        {
            return repository.getUserByID(id);
        }

        public Users addUser(Users user)
        {

            return repository.addUser(user);
        }  

        public Users loginUser(Users loginUser)
        {
            return repository.loginUser(loginUser);
        }

        public bool updateUser(int id, Users user)
        {
            var result = Zxcvbn.Core.EvaluatePassword(user.UserPassword);
            if (result.Score >= 2)
            {
                repository.updateUser(id, user);
                return true;
            }
            return false;
        }

    }
}
