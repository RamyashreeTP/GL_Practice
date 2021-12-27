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
    [Route("api/v1/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ICrudOperations<ProjectData> _repository;
        private readonly ApiDbContext _dbContext;
        public ProjectController(ICrudOperations<ProjectData> repository,ApiDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
            if (!_dbContext.Projects.Any())
            {
                _dbContext.Projects.Add(new ProjectData() { projectId = 1000, projectName = "ABC", projectDetail = "test project 1", createdOn = new DateTime() });
                _dbContext.Projects.Add(new ProjectData() { projectId = 1001, projectName = "MNO", projectDetail = "test project 2", createdOn = new DateTime() });
                _dbContext.Projects.Add(new ProjectData() { projectId = 1002, projectName = "XYZ", projectDetail = "test project 3", createdOn = new DateTime() });
                _dbContext.SaveChanges();
            }
        }
        [HttpGet("getAllProjects")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet("getProject/{prjId}")]
        public IActionResult Get(int prjId)
        {
            var res = _repository.Get(prjId);
            if (res == null)
                return NotFound("Project not found");
            return Ok(res);
        }
        [HttpPost("createProject")]
        public IActionResult Post(ProjectData prj)
        {
            var res = _repository.Create(prj);
            if (res == null)
                return BadRequest("Sorry !! Project can't be added");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + prj.projectId, prj);
        }
        [HttpDelete("deleteProject/{prjId}")]
        public IActionResult Delete(int prjId)
        {
            bool res = _repository.Delete(prjId);
            return res ? Ok("Record deleted successfully") : BadRequest("Project Id not found");
        }
        [HttpPut("updateProject")]
        public IActionResult Update(ProjectData prj)
        {
            var res = _repository.Update(prj);
            if (res == null)
                return BadRequest("Sorry !! Project can't be updated");
            return Ok(res);
        }
    }

}
