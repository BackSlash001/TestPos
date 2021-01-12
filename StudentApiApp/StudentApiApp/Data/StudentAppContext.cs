using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentApiApp.Models;

namespace StudentApiApp.Data
{
    public class StudentAppContext : DbContext
    {
        public StudentAppContext (DbContextOptions<StudentAppContext> options)
            : base(options)
        {
        }

        public DbSet<StudentApiApp.Models.Student> Student { get; set; }

        public DbSet<StudentApiApp.Models.Employee> Employee { get; set; }
    }
}
