using Microsoft.EntityFrameworkCore;

namespace API1.Controllers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<clothes>  clothess { get; set; }
        public DbSet<Stores> stores { get; set; }
    }
}
