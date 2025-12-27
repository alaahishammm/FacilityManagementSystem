using Microsoft.EntityFrameworkCore;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Domain.Enums;

namespace FacilityManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Asset> Assets { get; set; } = null!;
        public DbSet<Facility> facilities { get; set; } = null!;
        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // WorkOrder - Technician
            modelBuilder.Entity<WorkOrder>()
                .HasOne(w => w.Technician)
                .WithMany(u => u.AssignedWorkOrders)
                .HasForeignKey(w => w.TechnicianId)
                .OnDelete(DeleteBehavior.NoAction);

            // MaintenanceRequest - CreatedBy (User) REQUIRED
            modelBuilder.Entity<MaintenanceRequest>()
                .HasOne(w => w.CreatedBy)
                .WithMany(u => u.CreatedRequests)
                .HasForeignKey(w => w.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            // MaintenanceRequest - Asset OPTIONAL
            modelBuilder.Entity<MaintenanceRequest>()
                .HasOne(w => w.Asset)
                .WithMany(u => u.MaintenanceRequests)
                .HasForeignKey(w => w.AssetId)
                .OnDelete(DeleteBehavior.SetNull);

            // WorkOrder - MaintenanceRequest
            modelBuilder.Entity<WorkOrder>()
                .HasOne(w => w.MaintenanceRequest)
                .WithOne(u => u.WorkOrder)
                .HasForeignKey<WorkOrder>(w => w.MaintenanceRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Facility - Area
            modelBuilder.Entity<Facility>()
                .HasMany(f => f.Area)
                .WithOne(a => a.Facility)
                .HasForeignKey(a => a.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Area - Asset
            modelBuilder.Entity<Area>()
                .HasMany(a => a.Assets)
                .WithOne(a => a.Area)
                .HasForeignKey(a => a.AreaId)
                .OnDelete(DeleteBehavior.SetNull);

            // Facility - Asset
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Facility)
                .WithMany()
                .HasForeignKey(a => a.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);
            // Default value for Asset.Status
            modelBuilder.Entity<Asset>()
              .Property(a => a.Status)
              .HasDefaultValue(AssetStatus.Working);
        }
    }
}
