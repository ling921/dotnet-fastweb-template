using Ling.Shared.Models.UserDTO;

namespace Ling.Services.Services.Abstractions;

public interface IUserService
{
    Task<GetUserEndpoint> GetAsync(GetUserRequest model, CancellationToken cancellationToken = default);
    Task<QueryUserEndpoint> GetListAsync(QueryUserRequest model, CancellationToken cancellationToken = default);
    Task<CreateUserEndpoint> CreateAsync(CreateUserRequest model, CancellationToken cancellationToken = default);
    Task<UpdateUserEndpoint> UpdateAsync(UpdateUserRequest model, CancellationToken cancellationToken = default);
    Task<DeleteUserEndpoint> DeleteAsync(DeleteUserRequest model, CancellationToken cancellationToken = default);
}