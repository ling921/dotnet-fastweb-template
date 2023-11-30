using MyProject.Infrastructure.Services.Abstractions;
using MyProject.Core.Models.MyEntityDTO.Request;
using MyProject.Core.Models.MyEntityDTO.Response;

namespace MyProject.Infrastructure.Services;

internal class MyEntityService : IMyEntityService
{
    public Task<MyEntityDetailResponse> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MyEntityListItemResponse>> GetListAsync(QueryMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TKey> CreateAsync(CreateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TKey> UpdateAsync(TKey id, UpdateMyEntityRequest model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
