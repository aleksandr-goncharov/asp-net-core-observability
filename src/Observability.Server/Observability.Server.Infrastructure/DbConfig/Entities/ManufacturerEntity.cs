namespace Observability.Server.Infrastructure.DbConfig.Entities;

/// <summary>
/// Модель производителя для БД.
/// </summary>
public class ManufacturerEntity
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
    /// Страна производителя.
    /// </summary>
    public string Country { get; set; }
    
    /// <summary>
    /// Продукты производителя.
    /// </summary>
    public ICollection<ProductEntity> Products { get; set; }
}