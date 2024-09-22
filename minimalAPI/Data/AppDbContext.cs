using Microsoft.EntityFrameworkCore;
using minimalAPI.Models;

namespace minimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; } = null!;
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().Property(p => p.Name).HasMaxLength(150);
        }
    }
}
