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

        public Task<User> GetUserByIdasync(int id)
        {
            return _userRepository.GetUserByIdasync(id);
        }

        public Task<User> AddUserasync(User user)
        {

            return _userRepository.AddUserasync(user);
        }

        async public Task<User> LoginUserasync(User loginUser)
        {
            return await _userRepository.LoginUserasync(loginUser);
        }

        public bool UpdateUserasync(int id, User user)
        {
            var result = Zxcvbn.Core.EvaluatePassword(user.UserPassword);
            if (result.Score >= 2)
            {
                _userRepository.UpdateUserasync(id, user);
                return true;
            }
            return false;
        }

    }
}
