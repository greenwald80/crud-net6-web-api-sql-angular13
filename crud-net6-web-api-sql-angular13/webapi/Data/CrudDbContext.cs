using Microsoft.EntityFrameworkCore;

namespace webapi.Data
{
    public class CrudDbContext:DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {

        }
        public DbSet<webapi.Data.Entities.Student> Student { get; set; }
    }
}
