using Observability.Server.Api.Contracts.Manufactures.Common;

namespace Observability.Server.Api.Contracts.Manufactures.GetAll;

public record GetAllManufacturersResponse
{
    public required IReadOnlyCollection<ManufacturerBase> Manufacturers { get; init; }
}