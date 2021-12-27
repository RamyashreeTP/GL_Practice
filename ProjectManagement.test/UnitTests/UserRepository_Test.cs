using Microsoft.AspNetCore.Mvc;
using Moq;
using Projectmanagement.Models;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.test.UnitTests
{
    public class UserRepository_Test
    {
        private readonly Mock<ICrudOperations<UserData>> _userRepository;
        private readonly Mock<ApiDbContext> _dbContext;
        public UserRepository_Test()
        {
            _dbContext = new Mock<ApiDbContext>();
            _userRepository = new Mock<ICrudOperations<UserData>>();
        }
        [Fact]
        public void Task_GetUser_Return_OkResult()
        {
            UserData data = new UserData()
            {
                UserId = 101,
                FirstName = "Vimal",
                LastName = "Kashyap",
                Email = "vimal.K@gmail.com",
                Password = "vimal321"
            }; 
            _userRepository.Setup(x => x.Get(101)).Returns(data);
        }
        [Fact]
        public void Task_GetUsers_Return_OkResult()
        {
            List<UserData> data = new List<UserData>()
            {
                new UserData() { UserId = 101, FirstName = "Vimal", LastName = "Kashyap", Email = "vimal.K@gmail.com", Password = "vimal321" },
                new UserData() { UserId = 102, FirstName = "Subhod", LastName = "Gupta", Email = "subhoda@gmail.com", Password = "Hello@123" }
            };
            _userRepository.Setup(x => x.GetAll()).Returns(data);
        }
        [Fact]
        public void Task_CreateUser_Return_OkResult()
        {
            UserData data = new UserData()
            {
                UserId = 101,
                FirstName = "Vimal",
                LastName = "Kashyap",
                Email = "vimal.K@gmail.com",
                Password = "vimal321"
            };
            _userRepository.Setup(x => x.Create(data)).Returns(data);
        }
        [Fact]
        public void Task_DeleteUser_Return_OkResult()
        {
            _userRepository.Setup(x => x.Delete(101)).Returns(true);
        }
        [Fact]
        public void Task_UpdateUser_Return_OkResult()
        {
            UserData data = new UserData()
            {
                UserId = 101,
                FirstName = "Vimal",
                LastName = "Kashyap",
                Email = "vimal.K@gmail.com",
                Password = "vimal321"
            };
            List<UserData> res = new List<UserData>()
            {
                new UserData() { UserId = 101, FirstName = "Vimal", LastName = "Kashyap", Email = "vimal.K@gmail.com", Password = "vimal321" },
                new UserData() { UserId = 102, FirstName = "Subhod", LastName = "Gupta", Email = "subhoda@gmail.com", Password = "Hello@123" },
                new UserData() { UserId = 103, FirstName = "Manasa", LastName = "Bharadwaj", Email = "Manasa.Bh@gmail.com", Password = "PassMan###12" }
            };
            _userRepository.Setup(x => x.Update(data)).Returns(res);
        }
    }
}
