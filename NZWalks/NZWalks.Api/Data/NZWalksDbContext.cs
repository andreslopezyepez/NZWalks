using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
