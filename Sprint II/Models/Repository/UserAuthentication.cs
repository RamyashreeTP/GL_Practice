using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class UserAuthentication:IUserAuthentication
    {
        private ApiDbContext _dbContext;
        //List<LoginModel> validUsers = new();
        public UserAuthentication(ApiDbContext dbContext)
        {
            _dbContext=dbContext;
            /*validUsers.Add(new LoginModel() { userName = "user1", userPassword = "password1" });
            validUsers.Add(new LoginModel() { userName = "user2", userPassword = "password2" });
            validUsers.Add(new LoginModel() { userName = "user3", userPassword = "password3" });*/
        }
        public bool validateCredentials(string userName, string password)
        {
            bool res = _dbContext.ValidUsers.Any(x => x.userName.Equals(userName) && x.userPassword.Equals(password));
            return res;
        }
        public bool addUser(string userName, string password)
        {
            if (validateUsername(userName) && validatePassword(password))
            {
                _dbContext.ValidUsers.Add(new LoginModel() { userName = userName, userPassword = password });
                return true;
            }
            return false;
        }
        private bool validatePassword(string password)
        {
            const int min_length = 8;
            const int max_length = 15;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= min_length && password.Length <= max_length;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c))
                        hasUpperCaseLetter = true;
                    else if (char.IsLower(c))
                        hasLowerCaseLetter = true;
                    else if (char.IsDigit(c))
                        hasDecimalDigit = true;
                }
            }

            bool isValid = meetsLengthRequirements && hasUpperCaseLetter && hasLowerCaseLetter && hasDecimalDigit;
            return isValid;
        }
        private bool validateUsername(string userName)
        {
            return userName.All(Char.IsLetter);
        }
    }
}

