using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DiabCleanAPI
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> Employee { get; set ; }
        public DbSet<Company> Company { get; set ; }
        public AppDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cleanAPI.db"));
        }

    }
}
