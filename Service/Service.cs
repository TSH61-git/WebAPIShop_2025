using Entity;
using Repository;
using Zxcvbn;

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


        public int checkPasswordStrong(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
