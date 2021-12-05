using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{ 
    public class TaskProvider:ITaskProvider
    {
        private ApiContext _context;
        // public static List<Task> tasks = new();
        public TaskProvider(ApiContext context)
        {
            _context = context;
            /*tasks.Add(new Task() { taskId = 501, projectId = 1000, status = 1, userId = 101, detail = "task detail 1", createdOn = new DateTime() });
            tasks.Add(new Task() { taskId = 502, projectId = 1001, status = 1, userId = 102, detail = "task detail 2", createdOn = new DateTime() });
            tasks.Add(new Task() { taskId = 503, projectId = 1002, status = 2, userId = 103, detail = "task detail 3", createdOn = new DateTime() });*/
        }

        public Task CreateTask(Task obj)
        {
            int maxTaskId = _context.Tasks.Max(x => x.taskId);
            obj.taskId = ++maxTaskId;
            obj.createdOn = DateTime.Now;
            _context.Tasks.Add(obj);
            return obj;
        }

        public bool DeleteTask(int taskId)
        {
            if (_context.Tasks.Any(a => a.taskId == taskId))
            {
                Task task = GetTask(taskId);
                _context.Tasks.Remove(task);
                return true;
            }
            return false;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Tasks;
        }

        public Task GetTask(int taskId)
        {
            return _context.Tasks.FirstOrDefault(a => a.taskId == taskId);
        }

        public IEnumerable<Task> UpdateTask(Task obj)
        {
            var tasks = _context.Tasks;
            foreach (var ele in tasks)
            {
                if (ele.taskId == obj.taskId)
                {
                    ele.projectId = obj.projectId;
                    ele.status = obj.status;
                    ele.userId = obj.userId;
                    ele.detail = obj.detail;
                    ele.createdOn = DateTime.Now;
                }
            }
            return tasks;
        }
    }
}

