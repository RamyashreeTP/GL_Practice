using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public interface IProjectProvider
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProject(int prjId);
        Project CreateProject(Project obj);
        IEnumerable<Project> UpdateProject(Project obj);
        bool DeleteProject(int prjId);
    }
}
