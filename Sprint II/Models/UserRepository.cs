using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectmanagement.Models
{
    public class UserRepository : ICrudOperations<UserData>
    {
        readonly ApiDbContext _dbContext;
        public UserRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }         
        public UserData Create(UserData obj)
        {
            _dbContext.Users.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }
        public bool Delete(int id)
        {
            if (_dbContext.Users.Any(a => a.UserId == id))
            {
                UserData user = Get(id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public UserData Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(a => a.UserId == id);
        }

        public IEnumerable<UserData> GetAll()
        {
            return _dbContext.Users;
        }
        public IEnumerable<UserData> Update(UserData obj)
        {
            var users = _dbContext.Users;
            foreach (var ele in users)
            {
                if (ele.UserId == obj.UserId)
                {
                    ele.FirstName = obj.FirstName;
                    ele.LastName = obj.LastName;
                    ele.Email = obj.Email;
                    ele.Password = obj.Password;
                }
                _dbContext.SaveChanges();
            }
            return users;
        }
    }
}
