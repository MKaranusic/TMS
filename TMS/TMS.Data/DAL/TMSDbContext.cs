using Microsoft.EntityFrameworkCore;
using TMS.Data.Entities;

namespace TMS.Data.DAL;

public class TMSDbContext(DbContextOptions<TMSDbContext> options) : DbContext(options)
{
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("Tasks");
            entity.HasKey(t => t.Id);

            entity.HasIndex(t => t.StatusId);

            entity.HasOne(t => t.Status)
                  .WithMany()
                  .HasForeignKey(t => t.StatusId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<StatusEntity>(entity =>
        {
            entity.ToTable("Statuses");
            entity.HasKey(s => s.Id);
        });
    }
}
