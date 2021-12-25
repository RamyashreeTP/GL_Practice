using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectmanagement.Models
{
    public class ProjectRepository : ICrudOperations<ProjectData>
    {
        readonly ApiDbContext _dbContext;
        public ProjectRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ProjectData Create(ProjectData obj)
        {
            _dbContext.Projects.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            if (_dbContext.Projects.Any(a => a.projectId == id))
            {
                ProjectData project = Get(id);
                _dbContext.Projects.Remove(project);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public ProjectData Get(int id)
        {
            return _dbContext.Projects.FirstOrDefault(a => a.projectId == id);
        }

        public IEnumerable<ProjectData> GetAll()
        {
            return _dbContext.Projects;
        }

        public IEnumerable<ProjectData> Update(ProjectData obj)
        {
            var projects = _dbContext.Projects;
            foreach (var ele in projects)
            {
                if (ele.projectId == obj.projectId)
                {
                    ele.projectName = obj.projectName;
                    ele.projectDetail = obj.projectDetail;
                    ele.createdOn = DateTime.Now;
                }
                _dbContext.SaveChanges();
            }
            return projects;
        }
    }
}
