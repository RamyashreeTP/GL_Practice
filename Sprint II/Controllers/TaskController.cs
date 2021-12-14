using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projectmanagement.Models;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ICrudOperations<TaskData> _repository;
        private readonly ApiDbContext _dbContext;
        public TaskController(ICrudOperations<TaskData> taskProvider, ApiDbContext dbContext)
        {
            _repository = taskProvider;
            _dbContext = dbContext;
            if (!_dbContext.Tasks.Any())
            {
                _dbContext.Tasks.Add(new TaskData() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() });
                _dbContext.Tasks.Add(new TaskData() { taskId = 502, projectId = 1001, status = 1, userId = 102, detail = "task detail 2", createdOn = new DateTime() });
                _dbContext.Tasks.Add(new TaskData() { taskId = 503, projectId = 1002, status = 2, userId = 103, detail = "task detail 3", createdOn = new DateTime() });
                _dbContext.SaveChanges();
            }
        }
        [HttpGet("getAllTasks")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet("getTask/{taskId}")]
        public IActionResult Get(int taskId)
        {
            var res = _repository.Get(taskId);
            if (res == null)
                return NotFound("Task not found");
            return Ok(res);
        }
        [HttpPost("createTask")]
        public IActionResult Post(TaskData task)
        {
            var res = _repository.Create(task);
            if (res == null)
                return BadRequest("Sorry !! Task can't be added");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + task.taskId, task);
        }
        [HttpDelete("deleteTask/{taskId}")]
        public IActionResult Delete(int taskId)
        {
            bool res = _repository.Delete(taskId);
            return res ? Ok("Record deleted successfully") : BadRequest("Task Id not found");
        }
        [HttpPut("updateTask")]
        public IActionResult Update(TaskData task)
        {
            var res = _repository.Update(task);
            if (res == null)
                return BadRequest("Sorry !! Task can't be updated");
            return Ok(res);
        }
    }
}

