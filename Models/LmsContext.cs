using Microsoft.EntityFrameworkCore;

namespace LmsApi.Models
{
    public class LmsContext : DbContext
    {
        public LmsContext(DbContextOptions<LmsContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<History> Histories { get; set; } = null!;

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<History>().ToTable("History");
        }
    }
}