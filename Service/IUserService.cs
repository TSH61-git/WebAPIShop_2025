using DTOs;
using Entities;
using Repository.Models;

namespace Service
{
    public interface IUserService
    {
        Task<UserReadDTO> GetUserById(int id);

        Task<UserReadDTO> AddUser(UserRegisterDTO userRegisterDto);
        Task<UserReadDTO> LoginUser(UserLoginDTO userLoginDto);
        Task<bool> UpdateUser(int id, UserRegisterDTO userUpdateDto);
    }
}