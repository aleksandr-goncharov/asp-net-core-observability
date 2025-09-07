using Microsoft.EntityFrameworkCore;
using Observability.Server.Infrastructure.DbConfig.Entities;
using Observability.Server.Infrastructure.DbConfig.EntitiesConfigurations;

namespace Observability.Server.Infrastructure.DbConfig;

/// <summary>
/// DbContext для базы данных проекта.
/// </summary>
/// <param name="options"></param>
public sealed class ObservabilityAppDbContext(DbContextOptions<ObservabilityAppDbContext> options) : DbContext(options)
{
    public DbSet<ProductEntity>  Products => Set<ProductEntity>();
    public DbSet<ManufacturerEntity>  Manufacturers => Set<ManufacturerEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Сделано вручную, чтобы случайно не накосячить, но можно ApplyConfigurationsFromAssembly
        // использовать, чтобы само все конфигурации подтягивало.
        modelBuilder.ApplyConfiguration(new ProductDbConfiguration());
        modelBuilder.ApplyConfiguration(new ManufacturerDbConfiguration());
    }
}