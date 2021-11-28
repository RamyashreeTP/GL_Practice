using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public interface ITaskProvider
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTask(int taskId);
        Task CreateTask(Task obj);
        IEnumerable<Task> UpdateTask(Task obj);
        bool DeleteTask(int taskId);
    }
}
