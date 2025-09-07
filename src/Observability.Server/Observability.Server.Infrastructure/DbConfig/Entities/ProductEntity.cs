namespace Observability.Server.Infrastructure.DbConfig.Entities;

/// <summary>
/// Модель продукта для БД.
/// </summary>
public class ProductEntity
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public int Price { get; set; }
    
    /// <summary>
    /// Идентификатор производителя.
    /// </summary>
    public long ManufacturerId { get; set; }
    
    /// <summary>
    /// Производитель.
    /// </summary>
    public ManufacturerEntity Manufacturer { get; set; }
}