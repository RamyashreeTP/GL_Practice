using Moq;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.test.UnitTests
{
    public class UserAuthentication_Test
    {
        private readonly Mock<IUserAuthentication> _userAuthentication;
        private readonly Mock<ApiDbContext> _dbContext;
        public UserAuthentication_Test()
        {
            _dbContext = new Mock<ApiDbContext>();
            _userAuthentication = new Mock<IUserAuthentication>();
        }
        [Fact]
        public void Task_validateCredentials_Return_OkResult()
        {
            _userAuthentication.Setup(x => x.validateCredentials("user1", "abc")).Throws(new Exception());
        }
        [Fact]
        public void Task_addUser_Return_OkResult()
        {
            _userAuthentication.Setup(x => x.addUser("abc", "asdf32")).Throws(new Exception());
        }
    }
}
