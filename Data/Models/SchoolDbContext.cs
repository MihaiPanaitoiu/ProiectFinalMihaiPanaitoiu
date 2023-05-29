using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    internal class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public  DbSet<Address> Addresses { get; set; }
        public SchoolDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mihai\source\repos\ProiectFinalMihaiPanaitoiu\Data\SchoolDb.mdf;Integrated Security=True");
        }
    }
}
