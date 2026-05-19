using Microsoft.EntityFrameworkCore;
using AdjusterOptimizerAPI.Models;

namespace AdjusterOptimizerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Adjuster> Adjusters { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<PerformanceHistory> PerformanceHistory { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adjuster>().HasKey(a => a.AdjusterId);
            modelBuilder.Entity<Claim>().HasKey(c => c.ClaimId);
            modelBuilder.Entity<PerformanceHistory>().HasKey(p => p.RecordId);
            modelBuilder.Entity<Assignment>().HasKey(a => a.AssignmentId);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            modelBuilder.Entity<PerformanceHistory>()
                .HasOne(p => p.Adjuster)
                .WithMany(a => a.PerformanceHistory)
                .HasForeignKey(p => p.AdjusterId);

            modelBuilder.Entity<PerformanceHistory>()
                .HasOne(p => p.Claim)
                .WithMany(c => c.PerformanceHistory)
                .HasForeignKey(p => p.ClaimId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Adjuster)
                .WithMany(ad => ad.Assignments)
                .HasForeignKey(a => a.AdjusterId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Claim)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.ClaimId);
        }
    }
}
