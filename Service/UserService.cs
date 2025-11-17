using Entities;
using Repository;
using Zxcvbn;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Users getUserByID(int id)
        {
            return _userRepository.getUserByID(id);
        }

        public Users addUser(Users user)
        {

            return _userRepository.addUser(user);
        }

        public Users loginUser(Users loginUser)
        {
            return _userRepository.loginUser(loginUser);
        }

        public bool updateUser(int id, Users user)
        {
            var result = Zxcvbn.Core.EvaluatePassword(user.UserPassword);
            if (result.Score >= 2)
            {
                _userRepository.updateUser(id, user);
                return true;
            }
            return false;
        }

    }
}
