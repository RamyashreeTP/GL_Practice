using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectmanagement.Models
{
    public class TaskRepository : ICrudOperations<TaskData>
    {
        readonly ApiDbContext _dbContext;
        public TaskRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TaskData Create(TaskData obj)
        {
            _dbContext.Tasks.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            if (_dbContext.Tasks.Any(a => a.taskId == id))
            {
                TaskData task = Get(id);
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public TaskData Get(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(a => a.taskId == id);
        }

        public IEnumerable<TaskData> GetAll()
        {
            return _dbContext.Tasks;
        }

        public IEnumerable<TaskData> Update(TaskData obj)
        {
            var tasks = _dbContext.Tasks;
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
                _dbContext.SaveChanges();
            }
            return tasks;
        }
    }
}
