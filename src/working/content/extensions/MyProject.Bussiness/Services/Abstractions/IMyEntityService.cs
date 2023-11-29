using MyProject.Core.Models.MyEntityDTO;

namespace MyProject.Bussiness.Services.Abstractions;

public interface IMyEntityService
{
    Task<GetMyEntityEndpoint> GetAsync(GetMyEntityRequest model, CancellationToken cancellationToken = default);
    Task<QueryMyEntityEndpoint> GetListAsync(QueryMyEntityRequest model, CancellationToken cancellationToken = default);
    Task<CreateMyEntityEndpoint> CreateAsync(CreateMyEntityRequest model, CancellationToken cancellationToken = default);
    Task<UpdateMyEntityEndpoint> UpdateAsync(UpdateMyEntityRequest model, CancellationToken cancellationToken = default);
    Task<DeleteMyEntityEndpoint> DeleteAsync(DeleteMyEntityRequest model, CancellationToken cancellationToken = default);
}