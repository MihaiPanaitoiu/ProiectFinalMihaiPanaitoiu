using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public  DbSet<Address> Addresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
