using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PasswordService : IPasswordService
    {
        public Passwords CheckPasswordStrong(Passwords password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password.Password);
            password.Strength = result.Score;
            return password;
        }
        public Passwords CheckPasswordStrong(string password)
        {
            return CheckPasswordStrong(new Passwords { Password = password });
        }
        public bool IsPasswordStrong(string password, int minStrength = 2)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score >= minStrength;
        }

    }
}
