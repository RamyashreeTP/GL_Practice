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
        private readonly ApiContext _context;
        public ProjectController(IProjectProvider projectProvider,ApiContext context)
        {
            _projectProvider = projectProvider;
            _context = context;
            if (!_context.Projects.Any())
            {
                _context.Projects.Add(new Project() { projectId = 1000, projectName = "ABC", projectDetail = "test project 1", createdOn = new DateTime() });
                _context.Projects.Add(new Project() { projectId = 1001, projectName = "MNO", projectDetail = "test project 2", createdOn = new DateTime() });
                _context.Projects.Add(new Project() { projectId = 1002, projectName = "XYZ", projectDetail = "test project 3", createdOn = new DateTime() });
                _context.SaveChanges();
            }
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
