using cSharpCrud.Students;
using Microsoft.EntityFrameworkCore;

namespace cSharpCrud.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Stutents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlite(connectionString: "Data Source=DataBase.sqlite");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }
    }
}