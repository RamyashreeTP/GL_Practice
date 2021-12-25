using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projectmanagement.Models
{
    public class TaskData
    {
        [Key]
        public int taskId { get; set; }
        public int projectId { get; set; }
        public int status { get; set; }
        public int userId { get; set; }
        public string detail { get; set; }
        public DateTime createdOn { get; set; }
    }
}
