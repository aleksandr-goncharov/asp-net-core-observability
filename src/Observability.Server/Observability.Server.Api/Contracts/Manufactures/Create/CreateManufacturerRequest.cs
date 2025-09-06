namespace Observability.Server.Api.Contracts.Manufactures.Create;

public record CreateManufacturerRequest
{
    public required string Name { get; init; }
}