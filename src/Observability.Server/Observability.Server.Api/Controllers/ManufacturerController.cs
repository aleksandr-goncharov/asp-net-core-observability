using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Observability.Server.Api.Contracts.Manufactures.Common;
using Observability.Server.Api.Contracts.Manufactures.Create;
using Observability.Server.Api.Contracts.Manufactures.GetAll;

namespace Observability.Server.Api.Controllers;

[Route("[controller]")]
public class ManufacturerController : ControllerBase
{
    private class Manufacturer
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
    }

    private static long _lastId = 0;
    private static readonly ConcurrentDictionary<long, Manufacturer> Manufacturers = new();

    public async Task<GetAllManufacturersResponse> GetAll()
    {
        var manufacturers = Manufacturers.Values.Select(manufacturer => new ManufacturerBase
        {
            Id = manufacturer.Id,
            Name = manufacturer.Name
        }).ToArray();
        
        return new GetAllManufacturersResponse { Manufacturers = manufacturers };
    }
    
    public async Task<CreateManufacturerResponse> Create(CreateManufacturerRequest request)
    {
        var id = Interlocked.Increment(ref _lastId);
        Manufacturers[id] = new Manufacturer
        {
            Id = id,
            Name = request.Name
        };
        
        return new CreateManufacturerResponse { Id = id };
    }
}