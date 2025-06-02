using Microsoft.EntityFrameworkCore;
using Rackets.Domain.Model;

namespace Rackets.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Racket> Rackets { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.ClrType.GetProperties())
            {
                if (property.PropertyType.IsEnum)
                {
                    modelBuilder.Entity(entityType.Name)
                                .Property(property.Name)
                                .HasConversion<string>();
                }
            }
        }
        base.OnModelCreating(modelBuilder);
    }
}