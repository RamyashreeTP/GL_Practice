using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthentication _userService;
        private readonly ApiContext _context;
        public LoginController(IUserAuthentication userService,ApiContext context)
        {
            _userService = userService;
            _context = context;
            if (!_context.ValidUsers.Any())
            {
                _context.ValidUsers.Add(new LoginModel() { userName = "user1", userPassword = "password1" });
                _context.ValidUsers.Add(new LoginModel() { userName = "user2", userPassword = "password2" });
                _context.ValidUsers.Add(new LoginModel() { userName = "user3", userPassword = "password3" });
                _context.SaveChanges();
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

