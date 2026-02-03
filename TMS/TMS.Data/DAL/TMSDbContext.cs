using Microsoft.EntityFrameworkCore;
using TMS.Data.Entities;
using TMS.Data.Extensions;

namespace TMS.Data.DAL;

public class TMSDbContext(DbContextOptions<TMSDbContext> options) : DbContext(options)
{
    public DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("Tasks");
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Subject)
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(t => t.Description)
                  .HasMaxLength(2000);

            entity.Property(t => t.CreatedAt)
                  .IsRequired();

            entity.HasIndex(t => t.CreatedAt);
        });

        modelBuilder.SeedData();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries<TaskEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                var now = DateTime.UtcNow;
                entry.Entity.CreatedAt = now;
                entry.Entity.ModifiedAt = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }
        }
    }
}
