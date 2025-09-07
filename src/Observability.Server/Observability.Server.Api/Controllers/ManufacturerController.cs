using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Observability.Server.Api.Contracts.Manufactures.Common;
using Observability.Server.Api.Contracts.Manufactures.Create;
using Observability.Server.Api.Contracts.Manufactures.Delete;
using Observability.Server.Api.Contracts.Manufactures.GetAll;
using Observability.Server.Api.Contracts.Manufactures.GetById;
using Observability.Server.Api.Contracts.Manufactures.Update;

namespace Observability.Server.Api.Controllers;

/// <summary>
/// Контроллер для работы с производителями
/// </summary>
[Route("manufacturers")]
public class ManufacturerController : ControllerBase
{
    private class Manufacturer
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
    }

    private static long _lastId = 0;
    private static readonly ConcurrentDictionary<long, Manufacturer> Manufacturers = new();
    
    /// <summary>
    /// Получить полный список производителей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetAllManufacturersResponse> GetAll()
    {
        var manufacturers = Manufacturers.Values.Select(manufacturer => new ManufacturerBase
        {
            Id = manufacturer.Id,
            Name = manufacturer.Name
        }).ToArray();
        
        return new GetAllManufacturersResponse { Manufacturers = manufacturers };
    }
    
    /// <summary>
    /// Получить производителя по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    [HttpGet("{id:long}")]
    public async Task<GetManufacturerByIdResponse> GetById(long id)
    {
        var exists = Manufacturers.TryGetValue(id, out var manufacturer);

        if (!exists)
        {
            // TODO: создать класс исключения и настроить ExceptionHandler, чтобы он отдавал 404 статус-код
            throw new KeyNotFoundException();
        }
        
        return new GetManufacturerByIdResponse
        {
            Id = manufacturer!.Id,
            Name = manufacturer.Name
        };
    }
    
    /// <summary>
    /// Создать производителя
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ManufacturerIdResponse> Create(CreateManufacturerRequest request)
    {
        var id = Interlocked.Increment(ref _lastId);
        Manufacturers[id] = new Manufacturer
        {
            Id = id,
            Name = request.Name
        };

        return new ManufacturerIdResponse { Id = id };
    }
    
    /// <summary>
    /// Изменить производителя
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ManufacturerIdResponse> Update(UpdateManufacturerRequest request)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Удалить производителя
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete("{id:long}")]
    public async Task<DeleteManufacturerRequest> Delete(DeleteManufacturerRequest request)
    {
        throw new NotImplementedException();
    }
}