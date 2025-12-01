using Entities;
using Repository;
using Zxcvbn;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            if (!_passwordService.IsPasswordStrong(user.UserPassword))
                return null;
            return _userRepository.AddUser(user);
        }

        public User LoginUser(User loginUser)
        {
            return _userRepository.LoginUser(loginUser);
        }

        public bool UpdateUser(int id, User user)
        {
            if (!_passwordService.IsPasswordStrong(user.UserPassword))
                return false;
            _userRepository.UpdateUser(id, user);
            return true;
        }

    }
}
