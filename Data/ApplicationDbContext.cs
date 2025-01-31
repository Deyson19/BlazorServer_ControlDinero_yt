using Microsoft.EntityFrameworkCore;

namespace BlazorServer_ControlDinero.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { }
        
        //TODO: Run Migrations
        public DbSet<ControlDinero> ControlDineros { get; set; }
    }
}
