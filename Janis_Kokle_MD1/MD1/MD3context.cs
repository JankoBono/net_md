using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1
{
    public class MD3Context : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignement> Assignements { get; set; }
        public DbSet<Submission> Submissions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            optionsBuilder.UseSqlServer(cs);
        }
    }

}
