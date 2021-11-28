using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class UserProvider : IUserProvider
    {
        public static List<User> users = new();
        public UserProvider()
        {
            users.Add(new User() { UserId = 101, FirstName = "Vimal", LastName = "Kashyap", Email = "vimal.K@gmail.com", Password = "vimal321" });
            users.Add(new User() { UserId = 102, FirstName = "Subhod", LastName = "Gupta", Email = "subhoda@gmail.com", Password = "Hello@123" });
            users.Add(new User() { UserId = 103, FirstName = "Manasa", LastName = "Bharadwaj", Email = "Manasa.Bh@gmail.com", Password = "PassMan###12" });
        }
        public User CreateUser(User user)
        {
            int maxUserId = users.Max(x => x.UserId);
            user.UserId = ++maxUserId;
            users.Add(user);
            return user;
        }

        public bool DeleteUser(int userId)
        {
            if (users.Any(a => a.UserId == userId))
            {
                User user = GetUser(userId);
                users.Remove(user);
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public User GetUser(int userId)
        {
            return users.FirstOrDefault(a => a.UserId == userId);
        }

        public IEnumerable<User> UpdateUser(User user)
        {
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
