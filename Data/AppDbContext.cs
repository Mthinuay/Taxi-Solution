using Microsoft.EntityFrameworkCore;
using Adingisa.Models;

namespace Adingisa.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<TaxiLocation> TaxiLocations => Set<TaxiLocation>();
        public DbSet<TaxiRoute> TaxiRoutes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Comment (Cascade delete: deleting a User deletes their Comments)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment -> Reply (Restrict to avoid multiple cascade paths)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Reply)
                .WithMany()
                .HasForeignKey(c => c.ReplyID)
                .OnDelete(DeleteBehavior.Restrict);

            // Reply -> User (KEEP cascade)
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // Reply -> Post (CHANGE to Restrict or NoAction)
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Post)
                .WithMany()
                .HasForeignKey(r => r.PostID)
                .OnDelete(DeleteBehavior.Restrict); // or .NoAction

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Admin" },
                new Role { RoleID = 2, RoleName = "User" }
            );
        }
    }
}
