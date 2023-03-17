namespace MultiTenantTemplate.Application.Core;

public interface IBaseServices<TRequest, TResponse>
    where TRequest : RequestViewModel
    where TResponse : ResponseViewModel
{
    Task<IEnumerable<TResponse>> GetAll();
    Task<TResponse> GetById(Guid id);
    Task<int> Count();

    Task<TResponse> Create(TRequest createViewModel);
    Task<TResponse> Update(Guid id, TRequest updateViewModel);
    Task<bool> Delete(Guid id);
}