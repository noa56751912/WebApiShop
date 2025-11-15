using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Services
{
    public class ServicePassword
    {
        public int PasswordStrength(string password){
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
       
    }
}
