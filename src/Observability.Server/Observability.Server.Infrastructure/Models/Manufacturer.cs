namespace Observability.Server.Infrastructure.Models;

/// <summary>
/// Модель произваодителя.
/// </summary>
public class Manufacturer
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
}