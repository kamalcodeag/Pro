using Microsoft.EntityFrameworkCore;
using Pro.API.Entities;

namespace Pro.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "testuser1",
                    Email = "testuser1@gmail.com"
                },
                new User
                {
                    Id = 2,
                    UserName = "testuser2",
                    Email = "testuser2@gmail.com"
                }
            );
        }

    }
}
