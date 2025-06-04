using CloudManagementAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CloudManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CloudResource> CloudResources { get; set; }
        public DbSet<VirtualMachine> VirtualMachines { get; set; }
        public DbSet<StorageBucket> StorageBuckets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CloudResource>().ToTable("CloudResources");
            modelBuilder.Entity<VirtualMachine>().ToTable("VirtualMachines");
            modelBuilder.Entity<StorageBucket>().ToTable("StorageBuckets");

            modelBuilder.Entity<CloudResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Region).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ResourceType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<VirtualMachine>(entity =>
            {
                entity.Property(e => e.CPUCores).IsRequired();
                entity.Property(e => e.RAMGb).IsRequired();
                entity.Property(e => e.OS).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<StorageBucket>(entity =>
            {
                entity.Property(e => e.CapacityGb).IsRequired();
                entity.Property(e => e.IsEncrypted).IsRequired().HasDefaultValue(true);
            });
        }
    }
}
