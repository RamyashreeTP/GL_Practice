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
    public class TaskRepository_Test
    {
        private readonly Mock<ICrudOperations<TaskData>> _taskRepository;
        private readonly Mock<ApiDbContext> _dbContext;
        public TaskRepository_Test()
        {
            _dbContext = new Mock<ApiDbContext>();
            _taskRepository = new Mock<ICrudOperations<TaskData>>();
        }
        [Fact]
        public void Task_GetTask_Return_OkResult()
        {
            TaskData data = new TaskData() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() };
            _taskRepository.Setup(x => x.Get(101)).Returns(data);
        }
        [Fact]
        public void Task_GetTasks_Return_OkResult()
        {
            List<TaskData> data = new List<TaskData>()
            {
                new TaskData() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() },
                new TaskData() { taskId = 502, projectId = 1001, status = 1, userId = 102, detail = "task detail 2", createdOn = new DateTime() }
            };
            _taskRepository.Setup(x => x.GetAll()).Returns(data);
        }
        [Fact]
        public void Task_CreateTask_Return_OkResult()
        {
            TaskData data = new TaskData() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() };
            _taskRepository.Setup(x => x.Create(data)).Returns(data);
        }
        [Fact]
        public void Task_DeleteTask_Return_OkResult()
        {
            _taskRepository.Setup(x => x.Delete(101)).Returns(true);
        }
        [Fact]
        public void Task_UpdateTask_Return_OkResult()
        {
            TaskData data = new TaskData() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() };
            List<TaskData> res = new List<TaskData>()
            {
                new TaskData() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() },
                new TaskData() { taskId = 502, projectId = 1001, status = 1, userId = 102, detail = "task detail 2", createdOn = new DateTime() },
                new TaskData() { taskId = 503, projectId = 1002, status = 2, userId = 103, detail = "task detail 3", createdOn = new DateTime() }
            };
            _taskRepository.Setup(x => x.Update(data)).Returns(res);
        }
    }
}
