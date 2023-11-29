using Ling.Services.Services.Abstractions;
using Ling.Shared.Models.UserDTO;

namespace Ling.Services.Services.Abstractions;

internal class UserService : IUserService
{
    public Task<GetUserEndpoint> GetAsync(GetUserRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<QueryUserEndpoint> GetListAsync(QueryUserRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CreateUserEndpoint> CreateAsync(CreateUserRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateUserEndpoint> UpdateAsync(UpdateUserRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteUserEndpoint> DeleteAsync(DeleteUserRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }    
}
