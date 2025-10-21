using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Opstina> Opstine { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}