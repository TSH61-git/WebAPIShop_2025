using Entities;

namespace Service
{
    public interface IPasswordService
    {
        Passwords checkPasswordStrong(Passwords password);
        Passwords checkPasswordStrong(string password);
        bool isPasswordStrong(string password, int minStrength = 2);
    }
}