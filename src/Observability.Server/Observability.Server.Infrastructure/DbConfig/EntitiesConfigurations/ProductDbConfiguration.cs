using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Observability.Server.Infrastructure.DbConfig.Entities;

namespace Observability.Server.Infrastructure.DbConfig.EntitiesConfigurations;

/// <summary>
/// Конфигурация таблицы продукта.
/// </summary>
public sealed class ProductDbConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(product => product.Id);
        
        builder.Property(product => product.Id)
            .HasColumnName("product_id")
            .UseIdentityColumn()
            .IsRequired();
        
        builder.Property(product => product.Name)
            .HasColumnName("product_name")
            .IsRequired();

        builder.Property(product => product.Price)
            .HasColumnName("price");

        builder.Property(product => product.ManufacturerId)
            .UseIdentityColumn()
            .HasColumnName("manufacturer_id");

        builder.HasOne(product => product.Manufacturer)
            .WithMany(manufacturer => manufacturer.Products)
            .HasForeignKey(product => product.ManufacturerId);
    }
}