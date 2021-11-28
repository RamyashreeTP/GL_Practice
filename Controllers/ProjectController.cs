using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectProvider _projectProvider;
        public ProjectController(IProjectProvider projectProvider)
        {
            _projectProvider = projectProvider;
        }
        [HttpGet("getAllProjects")]
        public IActionResult Get()
        {
            return Ok(_projectProvider.GetAllProjects());
        }
        [HttpGet("getProject/{prjId}")]
        public IActionResult Get(int prjId)
        {
            var res = _projectProvider.GetProject(prjId);
            if (res == null)
                return NotFound("Project not found");
            return Ok(res);
        }
        [HttpPost("createProject")]
        public IActionResult Post(Project prj)
        {
            var res = _projectProvider.CreateProject(prj);
            if (res == null)
                return BadRequest("Sorry !! Project can't be added");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + prj.projectId, prj);
        }
        [HttpDelete("deleteProject/{prjId}")]
        public IActionResult DeleteProject(int prjId)
        {
            bool res = _projectProvider.DeleteProject(prjId);
            return res ? Ok("Record deleted successfully") : BadRequest("Project Id not found");
        }
        [HttpPut("updateProject")]
        public IActionResult UpdateProject(Project prj)
        {
            var res = _projectProvider.UpdateProject(prj);
            if (res == null)
                return BadRequest("Sorry !! Project can't be updated");
            return Ok(res);
        }
    }

}
