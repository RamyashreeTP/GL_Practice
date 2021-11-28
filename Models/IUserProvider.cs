using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public interface IUserProvider
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(int userId);
        User CreateUser(User user);
        IEnumerable<User> UpdateUser(User user);
        bool DeleteUser(int userId);
    }
}
