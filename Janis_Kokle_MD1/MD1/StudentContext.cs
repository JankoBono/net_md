using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD1
{
    public class StudentContext : DbContext
    {
        DbSet<Student> Studenti { get; set; }
        DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string cs = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        optionsBuilder.UseSqlServer(cs);
    }
    }

}
