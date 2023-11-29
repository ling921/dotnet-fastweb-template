using Ling.Services.Services.Abstractions;

namespace Ling.Api.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<QueryUserEndpoint> GetAsync([FromQuery] QueryUserRequest model, CancellationToken cancellationToken = default)
    {
        return _service.GetAsync(model, cancellationToken);
    }

    [HttpGet]
    public Task<QueryUserEndpoint> GetList([FromQuery] QueryUserRequest model, CancellationToken cancellationToken = default)
    {
        return _service.GetAsync(model, cancellationToken);
    }

    [HttpPost]
    public Task<CreateUserEndpoint> CreateAsync([FromBody] CreateUserRequest model, CancellationToken cancellationToken = default)
    {
        return _service.CreateAsync(model, cancellationToken);
    }

    [HttpPut]
    public Task<UpdateUserEndpoint> UpdateAsync([FromBody] UpdateUserRequest model, CancellationToken cancellationToken = default)
    {
        return _service.UpdateAsync(model, cancellationToken);
    }

    [HttpDelete]
    public Task<DeleteUserEndpoint> DeleteAsync([FromBody] DeleteUserRequest model, CancellationToken cancellationToken = default)
    {
        return _service.DeleteAsync(model, cancellationToken);
    }
}
