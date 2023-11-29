using MyProject.Infrastructure.Services.Abstractions;
using MyProject.Core.Models.MyEntityDTO;

namespace MyProject.Infrastructure.Services.Abstractions;

internal class MyEntityService : IMyEntityService
{
    public Task<GetMyEntityEndpoint> GetAsync(GetMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<QueryMyEntityEndpoint> GetListAsync(QueryMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CreateMyEntityEndpoint> CreateAsync(CreateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateMyEntityEndpoint> UpdateAsync(UpdateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteMyEntityEndpoint> DeleteAsync(DeleteMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }    
}
