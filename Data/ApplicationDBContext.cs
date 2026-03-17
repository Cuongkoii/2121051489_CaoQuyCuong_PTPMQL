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

        //  THÊM DÒNG NÀY
        public DbSet<Student> Students { get; set; }
    }
}