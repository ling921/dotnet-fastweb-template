using MyProject.Bussiness.Services.Abstractions;

namespace MyProject.WebApi.Controllers;

public class MyEntityController : ControllerBase
{
    private readonly IMyEntityService _service;

    public MyEntityController(IMyEntityService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<QueryMyEntityEndpoint> GetAsync([FromQuery] QueryMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.GetAsync(model, cancellationToken);
    }

    [HttpGet]
    public Task<QueryMyEntityEndpoint> GetList([FromQuery] QueryMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.GetAsync(model, cancellationToken);
    }

    [HttpPost]
    public Task<CreateMyEntityEndpoint> CreateAsync([FromBody] CreateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.CreateAsync(model, cancellationToken);
    }

    [HttpPut]
    public Task<UpdateMyEntityEndpoint> UpdateAsync([FromBody] UpdateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.UpdateAsync(model, cancellationToken);
    }

    [HttpDelete]
    public Task<DeleteMyEntityEndpoint> DeleteAsync([FromBody] DeleteMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        return _service.DeleteAsync(model, cancellationToken);
    }
}
