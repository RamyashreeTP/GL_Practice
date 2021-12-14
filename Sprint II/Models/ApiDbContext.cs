using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projectmanagement.Models;

namespace ProjectManagement.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }
        public DbSet<LoginModel> ValidUsers { get; set; }
        public DbSet<UserData> Users { get; set; }
        public DbSet<ProjectData> Projects { get; set; }
        public DbSet<TaskData> Tasks { get; set; }
    }
}
