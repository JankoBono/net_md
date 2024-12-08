using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MD1
{
    public class MD3Context : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignement> Assignements { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        //------------ Šī koda daļa tika daļēji uzbūvēta ar mākslīgā intelekta palīdzību, jo bija kļūdas par appsettings.json neesamību --------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("MyConn");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'MyConn' not found in appsettings.json.");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, konfigurējot datubāzes konekciju: {ex.Message}");
                throw; // Pārmet kļūdu tālāk, lai tā būtu zināma arī augstākajam līmenim
            }
        }
        //-----------------------------------AI koda beigas--------------------------------------
    }

}
