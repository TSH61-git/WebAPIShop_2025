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

        public Passwords checkPasswordStrong(Passwords password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password.password);
            password.Strength = result.Score;
            return password;
        }
        public Passwords checkPasswordStrong(string password)
        {
            return checkPasswordStrong(new Passwords { password = password });
        }
        public bool isPasswordStrong(string password, int minStrength = 2)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score >= minStrength;
        }

    }
}
