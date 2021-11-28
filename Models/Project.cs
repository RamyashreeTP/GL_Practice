using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class Project
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public string projectDetail { get; set; }
        public DateTime createdOn { get; set; }
    }
}
