using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/v1/Authentication")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthentication _userService;
        private readonly ApiDbContext _dbContext;
        public LoginController(IUserAuthentication userService,ApiDbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
            if (!_dbContext.ValidUsers.Any())
            {
                _dbContext.ValidUsers.Add(new LoginModel() { userName = "user1", userPassword = "password1" });
                _dbContext.ValidUsers.Add(new LoginModel() { userName = "user2", userPassword = "password2" });
                _dbContext.ValidUsers.Add(new LoginModel() { userName = "user3", userPassword = "password3" });
                _dbContext.SaveChanges();
            }
        }
        [HttpPost("login")]
        public IActionResult validateCredentials(string uname, string pwd)
        {
            bool res = _userService.validateCredentials(uname, pwd);
            if (res)
                return Ok(new { status = 200, isSuccess = true, message = "User Login successfull" });
            else
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
        }
        [HttpPost("addUser")]
        public IActionResult addUser(string uname, string pwd)
        {
            bool res = _userService.addUser(uname, pwd);
            if (res)
                return Ok("User added successfully");
            else
                return BadRequest("Invalid username/password");
        }
    }
}

