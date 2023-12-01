using MyProject.Core.Models.MyEntityDTO.Request;
using MyProject.Core.Models.MyEntityDTO.Response;

namespace MyProject.Infrastructure.Services.Abstractions;

public interface IMyEntityService
{
    Task<MyEntityDetailResponse> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task<IEnumerable<MyEntityListItemResponse>> GetListAsync(QueryMyEntityRequest model, CancellationToken cancellationToken = default);
    Task<TKey> CreateAsync(CreateMyEntityRequest model, CancellationToken cancellationToken = default);
    Task<TKey> UpdateAsync(TKey id, UpdateMyEntityRequest model, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);
}