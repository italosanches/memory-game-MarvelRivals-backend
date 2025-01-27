using MemoryGame.Entityes;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserScore> UsersScore { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserScore>(entity =>
            {
                entity.Property(e => e.GameTime).HasColumnType("time(3)");
            });
        }
    }
}
