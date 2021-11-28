using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class ProjectProvider:IProjectProvider
    {
        public static List<Project> projects = new();
        public ProjectProvider()
        {
            projects.Add(new Project() { projectId = 1000, projectName = "ABC", projectDetail = "test project 1", createdOn = new DateTime() });
            projects.Add(new Project() { projectId = 1001, projectName = "MNO", projectDetail = "test project 2", createdOn = new DateTime() });
            projects.Add(new Project() { projectId = 1002, projectName = "XYZ", projectDetail = "test project 3", createdOn = new DateTime() });
        }
        public Project CreateProject(Project obj)
        {
            int maxProjId = projects.Max(x => x.projectId);
            obj.projectId = ++maxProjId;
            obj.createdOn = DateTime.Now;
            projects.Add(obj);
            return obj;
        }

        public bool DeleteProject(int prjId)
        {
            if (projects.Any(a => a.projectId == prjId))
            {
                Project proj = GetProject(prjId);
                projects.Remove(proj);
                return true;
            }
            return false;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return projects;

        }
        public Project GetProject(int prjId)
        {
            return projects.FirstOrDefault(a => a.projectId == prjId);
        }

        public IEnumerable<Project> UpdateProject(Project obj)
        {
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
