using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        private readonly ApiContext _context;
        public UserController(IUserProvider userProvider, ApiContext context)
        {
            _userProvider = userProvider;
            _context = context;
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User() { UserId = 101, FirstName = "Vimal", LastName = "Kashyap", Email = "vimal.K@gmail.com", Password = "vimal321" });
                _context.Users.Add(new User() { UserId = 102, FirstName = "Subhod", LastName = "Gupta", Email = "subhoda@gmail.com", Password = "Hello@123" });
                _context.Users.Add(new User() { UserId = 103, FirstName = "Manasa", LastName = "Bharadwaj", Email = "Manasa.Bh@gmail.com", Password = "PassMan###12" });
                _context.SaveChanges();
            }
        }
        [HttpGet("getAllUsers")]
        public IActionResult Get()
        {
            return Ok(_userProvider.GetAllUsers());
        }
        [HttpGet("getUser/{userId}")]
        public IActionResult Get(int userId)
        {
            var res = _userProvider.GetUser(userId);
            if (res == null)
                return NotFound("User not found");
            return Ok(res);
        }
        [HttpPost("createUser")]
        public IActionResult Post(User user)
        {
            var res = _userProvider.CreateUser(user);
            if (res == null)
                return BadRequest("Sorry !! User can't be added");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.UserId, user);
        }
        [HttpDelete("deleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            bool res = _userProvider.DeleteUser(userId);
            return res ? Ok("Record deleted successfully") : BadRequest("User Id not found");
        }
        [HttpPut("updateUser")]
        public IActionResult UpdateUser(User user)
        {
            var res = _userProvider.UpdateUser(user);
            if (res == null)
                return BadRequest("Sorry !! User can't be updated");
            return Ok(res);
        }
    }
}

