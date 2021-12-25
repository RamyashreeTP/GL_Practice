using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public interface IUserAuthentication
    {
        bool validateCredentials(string userName, string password);
        bool addUser(string userName, string password);
    }
}
