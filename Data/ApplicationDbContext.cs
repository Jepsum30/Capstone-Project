using Microsoft.EntityFrameworkCore;
using AdjusterOptimizerAPI.Models;

namespace AdjusterOptimizerAPI.Data
{
    /// <summary>
    /// Central Entity Framework Core database context for the Adjuster Workload Optimizer.
    /// Maps C# models to MySQL tables and configures all relationships.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor that passes configuration options to the base DbContext.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // ------------------------------------------------------------
        // Database Tables (DbSets)
        // ------------------------------------------------------------

        public DbSet<Adjuster> Adjusters { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<PerformanceHistory> PerformanceHistory { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }

        // ------------------------------------------------------------
        // Model Configuration
        // ------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Primary Keys
    modelBuilder.Entity<Adjuster>().HasKey(a => a.AdjusterId);
    modelBuilder.Entity<Claim>().HasKey(c => c.ClaimId);
    modelBuilder.Entity<PerformanceHistory>().HasKey(p => p.RecordId);
    modelBuilder.Entity<Assignment>().HasKey(a => a.AssignmentId);
    modelBuilder.Entity<User>().HasKey(u => u.UserId);

    // PerformanceHistory → Adjuster
    modelBuilder.Entity<PerformanceHistory>()
        .HasOne(p => p.Adjuster)
        .WithMany(a => a.PerformanceHistory)
        .HasForeignKey(p => p.AdjusterId)
        .OnDelete(DeleteBehavior.Restrict);

    // PerformanceHistory → Claim
    modelBuilder.Entity<PerformanceHistory>()
        .HasOne(p => p.Claim)
        .WithMany(c => c.PerformanceHistory)
        .HasForeignKey(p => p.ClaimId)
        .OnDelete(DeleteBehavior.Restrict);

    // Assignment → Adjuster
    modelBuilder.Entity<Assignment>()
        .HasOne(a => a.Adjuster)
        .WithMany(ad => ad.Assignments)
        .HasForeignKey(a => a.AdjusterId)
        .OnDelete(DeleteBehavior.Restrict);

    // Assignment → Claim
    modelBuilder.Entity<Assignment>()
        .HasOne(a => a.Claim)
        .WithMany(c => c.Assignments)
        .HasForeignKey(a => a.ClaimId)
        .OnDelete(DeleteBehavior.Restrict);
}

    }
}
