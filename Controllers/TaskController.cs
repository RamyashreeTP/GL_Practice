using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ITaskProvider _taskProvider;
        public TaskController(ITaskProvider taskProvider)
        {
            _taskProvider = taskProvider;
        }
        [HttpGet("getAllTasks")]
        public IActionResult Get()
        {
            return Ok(_taskProvider.GetAllTasks());
        }
        [HttpGet("getTask/{taskId}")]
        public IActionResult Get(int taskId)
        {
            var res = _taskProvider.GetTask(taskId);
            if (res == null)
                return NotFound("Task not found");
            return Ok(res);
        }
        [HttpPost("createTask")]
        public IActionResult Post(Task task)
        {
            var res = _taskProvider.CreateTask(task);
            if (res == null)
                return BadRequest("Sorry !! Task can't be added");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + task.taskId, task);
        }
        [HttpDelete("deleteTask/{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            bool res = _taskProvider.DeleteTask(taskId);
            return res ? Ok("Record deleted successfully") : BadRequest("Task Id not found");
        }
        [HttpPut("updateTask")]
        public IActionResult UpdateTask(Task task)
        {
            var res = _taskProvider.UpdateTask(task);
            if (res == null)
                return BadRequest("Sorry !! Task can't be updated");
            return Ok(res);
        }
    }
}
