using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projectmanagement.Models
{
    public class ProjectData
    {
        [Key]
        public int projectId { get; set; }
        public string projectName { get; set; }
        public string projectDetail { get; set; }
        public DateTime createdOn { get; set; }
    }
}
