namespace Observability.Server.Infrastructure.Models;

/// <summary>
/// Модель продукта.
/// </summary>
public class Product
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
}