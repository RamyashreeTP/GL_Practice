using Moq;
using Projectmanagement.Models;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.test.UnitTests
{
    public class ProjectRepository_Test
    {
        private readonly Mock<ICrudOperations<ProjectData>> _projectRepository;
        private readonly Mock<ApiDbContext> _dbContext;
        public ProjectRepository_Test()
        {
            _dbContext = new Mock<ApiDbContext>();
            _projectRepository = new Mock<ICrudOperations<ProjectData>>();
        }
        [Fact]
        public void Task_GetProject_Return_OkResult()
        {
            ProjectData data = new ProjectData()
            {
                projectId = 1000, projectName = "ABC", projectDetail = "test project 1", createdOn = new DateTime()
            };
            _projectRepository.Setup(x => x.Get(101)).Returns(data);
        }
        [Fact]
        public void Task_GetProjects_Return_OkResult()
        {
            List<ProjectData> data = new List<ProjectData>()
            {
                new ProjectData() { projectId = 1000, projectName = "ABC", projectDetail = "test project 1", createdOn = new DateTime() },
                new ProjectData() { projectId = 1001, projectName = "MNO", projectDetail = "test project 2", createdOn = new DateTime() }
            };
            _projectRepository.Setup(x => x.GetAll()).Returns(data);
        }
        [Fact]
        public void Task_CreateProject_Return_OkResult()
        {
            ProjectData data = new ProjectData()
            {
                projectId = 1000,
                projectName = "ABC",
                projectDetail = "test project 1",
                createdOn = new DateTime()
            };
            _projectRepository.Setup(x => x.Create(data)).Returns(data);
        }
        [Fact]
        public void Task_DeleteUser_Return_OkResult()
        {
            _projectRepository.Setup(x => x.Delete(101)).Returns(true);
        }
        [Fact]
        public void Task_UpdateProject_Return_OkResult()
        {
            ProjectData data = new ProjectData()
            {
                projectId = 1000,
                projectName = "ABC",
                projectDetail = "test project 1",
                createdOn = new DateTime()
            };
            List<ProjectData> res = new List<ProjectData>()
            {
                new ProjectData() { projectId = 1000, projectName = "ABC", projectDetail = "test project 1", createdOn = new DateTime() },
                new ProjectData() { projectId = 1001, projectName = "MNO", projectDetail = "test project 2", createdOn = new DateTime() },
                new ProjectData() { projectId = 1002, projectName = "XYZ", projectDetail = "test project 3", createdOn = new DateTime() }
            };
            _projectRepository.Setup(x => x.Update(data)).Returns(res);
        }
    }
}
