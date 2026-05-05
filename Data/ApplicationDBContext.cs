using Microsoft.EntityFrameworkCore;
using ptpmql.Models;

namespace ptpmql.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
         public DbSet<Supplier> Suppliers { get; set; }
        
    }
}