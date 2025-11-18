using Entities;

namespace Service
{
    public interface IPasswordService
    {
        Passwords CheckPasswordStrong(Passwords password);
        Passwords CheckPasswordStrong(string password);
        bool IsPasswordStrong(string password, int minStrength = 2);
    }
}