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

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> AddUser(User user)
        {

            return await _userRepository.AddUser(user);
        }

        async public Task<User> LoginUser(User loginUser)
        {
            return await _userRepository.LoginUser(loginUser);
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            if (!_passwordService.IsPasswordStrong(user.UserPassword))
                return false;
            await _userRepository.UpdateUser(id, user);
            return true;
        }

    }
}
