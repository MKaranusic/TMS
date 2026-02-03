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
        });

        modelBuilder.SeedData();
    }
}
