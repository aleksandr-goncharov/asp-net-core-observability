using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Observability.Server.Infrastructure.DbConfig.Entities;

namespace Observability.Server.Infrastructure.DbConfig.EntitiesConfigurations;

/// <summary>
/// Конфигурация таблицы производителя.
/// </summary>
public sealed class ManufacturerDbConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
    {
        builder.ToTable("Manufacturers");
        builder.HasKey(manufacturer => manufacturer.Id);
        
        builder.Property(manufacturer => manufacturer.Id)
            .HasColumnName("manufacturer_id")
            .UseIdentityColumn()
            .IsRequired();
        
        builder.Property(manufacturer => manufacturer.Name)
            .HasColumnName("manufacturer_name")
            .IsRequired();

        builder.Property(manufacturer => manufacturer.Country)
            .HasColumnName("country");
    }
}