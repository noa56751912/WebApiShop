using Zxcvbn;

namespace Services
{
    public class PasswordServices : IPasswordServices
    {
        public int PasswordStrength(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}
