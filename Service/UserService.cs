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

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User AddUser(User user)
        {

            return _userRepository.AddUser(user);
        }

        public User LoginUser(User loginUser)
        {
            return _userRepository.LoginUser(loginUser);
        }

        public bool UpdateUser(int id, User user)
        {
            var result = Zxcvbn.Core.EvaluatePassword(user.UserPassword);
            if (result.Score >= 2)
            {
                _userRepository.UpdateUser(id, user);
                return true;
            }
            return false;
        }

    }
}
