using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projectmanagement.Models;
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
        private readonly ICrudOperations<UserData> _repository;
        private readonly ApiDbContext _dbContext;
        public UserController(ICrudOperations<UserData> repository, ApiDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
            if (!_dbContext.Users.Any())
            {
                _dbContext.Users.Add(new UserData() { UserId = 101, FirstName = "Vimal", LastName = "Kashyap", Email = "vimal.K@gmail.com", Password = "vimal321" });
                _dbContext.Users.Add(new UserData() { UserId = 102, FirstName = "Subhod", LastName = "Gupta", Email = "subhoda@gmail.com", Password = "Hello@123" });
                _dbContext.Users.Add(new UserData() { UserId = 103, FirstName = "Manasa", LastName = "Bharadwaj", Email = "Manasa.Bh@gmail.com", Password = "PassMan###12" });
                _dbContext.SaveChanges();
            }
        }
        [HttpGet("getAllUsers")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet("getUser/{userId}")]
        public IActionResult Get(int userId)
        {
            var res = _repository.Get(userId);
            if (res == null)
                return NotFound("Not found");
            return Ok(res);
        }
        [HttpPost("createUser")]
        public IActionResult Post(UserData user)
        {
            var res = _repository.Create(user);
            if (res == null)
                return BadRequest("Sorry !! User can't be added");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.UserId, user);
        }
        [HttpDelete("deleteUser/{userId}")]
        public IActionResult Delete(int id)
        {
            bool res = _repository.Delete(id);
            return res ? Ok("Record deleted successfully") : BadRequest("Not found");
        }
        [HttpPut("updateUser")]
        public IActionResult Update(UserData user)
        {
            var res = _repository.Update(user);
            if (res == null)
                return BadRequest("Sorry !! Can't be updated");
            return Ok(res);
        }
    }
}

