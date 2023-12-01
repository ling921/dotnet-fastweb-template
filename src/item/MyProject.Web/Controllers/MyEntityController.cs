using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Models.MyEntityDTO.Request;
using MyProject.Core.Models.MyEntityDTO.Response;
using MyProject.Infrastructure.Services.Abstractions;

namespace MyProject.Web.Controllers;

[Route("api/[controller]")]
public class MyEntityController : ControllerBase
{
    private readonly IMyEntityService _service;

    public MyEntityController(IMyEntityService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public Task<MyEntityDetailResponse> GetAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return _service.GetByIdAsync(id, cancellationToken);
    }

    [HttpGet("")]
    public Task<IEnumerable<MyEntityListItemResponse>> GetListAsync([FromQuery] QueryMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.GetListAsync(model, cancellationToken);
    }

    [HttpPost]
    public Task<TKey> CreateAsync([FromBody] CreateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.CreateAsync(model, cancellationToken);
    }

    [HttpPut("{id}")]
    public Task<TKey> UpdateAsync(TKey id, [FromBody] UpdateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.UpdateAsync(id, model, cancellationToken);
    }

    [HttpDelete("{id}")]
    public Task<int> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return _service.DeleteAsync(new[] { id }, cancellationToken);
    }
}
