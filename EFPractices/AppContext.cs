using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFPractices
{
    public class AppContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress02;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }
    }
}

