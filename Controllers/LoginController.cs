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
        public LoginController(IUserAuthentication userService)
        {
            _userService = userService;
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
