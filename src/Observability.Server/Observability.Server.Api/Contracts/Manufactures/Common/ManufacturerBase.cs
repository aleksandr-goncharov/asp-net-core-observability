namespace Observability.Server.Api.Contracts.Manufactures.Common;

public record ManufacturerBase
{
    public required long Id { get; init; }
    
    public required string Name { get; init; }
}