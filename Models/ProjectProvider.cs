using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class ProjectProvider:IProjectProvider
    {
        private ApiContext _context;
        //public static List<Project> projects = new();
        public ProjectProvider(ApiContext context)
        {
            _context = context;
            /*projects.Add(new Project() { projectId = 1000, projectName = "ABC", projectDetail = "test project 1", createdOn = new DateTime() });
            projects.Add(new Project() { projectId = 1001, projectName = "MNO", projectDetail = "test project 2", createdOn = new DateTime() });
            projects.Add(new Project() { projectId = 1002, projectName = "XYZ", projectDetail = "test project 3", createdOn = new DateTime() });*/
        }
        public Project CreateProject(Project obj)
        {
            int maxProjId = _context.Projects.Max(x => x.projectId);
            obj.projectId = ++maxProjId;
            obj.createdOn = DateTime.Now;
            _context.Projects.Add(obj);
            return obj;
        }

        public bool DeleteProject(int prjId)
        {
            if (_context.Projects.Any(a => a.projectId == prjId))
            {
                Project proj = GetProject(prjId);
                _context.Projects.Remove(proj);
                return true;
            }
            return false;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects;

        }
        public Project GetProject(int prjId)
        {
            return _context.Projects.FirstOrDefault(a => a.projectId == prjId);
        }

        public IEnumerable<Project> UpdateProject(Project obj)
        {
            var projects = _context.Projects;
            foreach (var ele in projects)
            {
                if (ele.projectId == obj.projectId)
                {
                    ele.projectName = obj.projectName;
                    ele.projectDetail = obj.projectDetail;
                    ele.createdOn = DateTime.Now;
                }
            }
            return projects;
        }
    }
}

