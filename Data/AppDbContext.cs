using Microsoft.EntityFrameworkCore;
using Adingisa.Models;

namespace Adingisa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
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
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment -> Reply (Restrict to avoid multiple cascade paths)
            modelBuilder.Entity<Reply>()
    .HasOne(r => r.Comment)
    .WithMany(c => c.Replies)
    .HasForeignKey(r => r.CommentId)
    .OnDelete(DeleteBehavior.Restrict); // or Cascade, if you prefer


            // Reply -> User (KEEP cascade)
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Reply -> Post (CHANGE to Restrict or NoAction)
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Post)
                .WithMany()
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict); // or .NoAction

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "User" }
            );
        }
    }
}
