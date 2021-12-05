using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class UserProvider : IUserProvider
    {
        private ApiContext _context;
       // public static List<User> users = new();
        public UserProvider(ApiContext context)
        {
            _context = context;
            /*users.Add(new User() { UserId = 101, FirstName = "Vimal", LastName = "Kashyap", Email = "vimal.K@gmail.com", Password = "vimal321" });
            users.Add(new User() { UserId = 102, FirstName = "Subhod", LastName = "Gupta", Email = "subhoda@gmail.com", Password = "Hello@123" });
            users.Add(new User() { UserId = 103, FirstName = "Manasa", LastName = "Bharadwaj", Email = "Manasa.Bh@gmail.com", Password = "PassMan###12" });*/
        }
        public User CreateUser(User user)
        {
            int maxUserId = _context.Users.Max(x => x.UserId);
            user.UserId = ++maxUserId;
            _context.Users.Add(user);
            return user;
        }

        public bool DeleteUser(int userId)
        {
            if (_context.Users.Any(a => a.UserId == userId))
            {
                User user = GetUser(userId);
                _context.Users.Remove(user);
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(a => a.UserId == userId);
        }

        public IEnumerable<User> UpdateUser(User user)
        {
            var users = _context.Users;
            foreach (var ele in users)
            {
                if (ele.UserId == user.UserId)
                {
                    ele.FirstName = user.FirstName;
                    ele.LastName = user.LastName;
                    ele.Email = user.Email;
                    ele.Password = user.Password;
                }
            }
            return users;
        }
    }
}
