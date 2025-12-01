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

        public Task<User> GetUserByIdasync(int id)
        {
            return _userRepository.GetUserByIdasync(id);
        }

        public Task<User> AddUserasync(User user)
        {

            return _userRepository.AddUser(user);
        }

        async public Task<User> LoginUserasync(User loginUser)
        {
            return await _userRepository.LoginUserasync(loginUser);
        }

        public bool UpdateUserasync(int id, User user)
        {
            if (!_passwordService.IsPasswordStrong(user.UserPassword))
                return false;
            _userRepository.UpdateUser(id, user);
            return true;
        }

    }
}
