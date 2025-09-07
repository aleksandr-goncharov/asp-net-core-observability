namespace Observability.Server.Api.Contracts.Manufactures.Delete;

public record DeleteManufacturerRequest
{
    public required long Id { get; init; }
}