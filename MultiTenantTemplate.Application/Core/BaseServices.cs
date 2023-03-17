using AutoMapper;
using MultiTenantTemplate.Domain.Core;
using MultiTenantTemplate.Domain.Transactions;
using MultiTenantTemplate.Infra.Data.Core;

namespace MultiTenantTemplate.Application.Core;

public class BaseServices<TEntity, TRepository, TRequest, TResponse>
    : IBaseServices<TRequest, TResponse>
    where TEntity : Entity
    where TRepository : IBaseRepository<TEntity>
    where TRequest : RequestViewModel
    where TResponse : ResponseViewModel
{
    private readonly TRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BaseServices(
        TRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TResponse>> GetAll()
       => _mapper.Map<IEnumerable<TResponse>>
       (await _repository.GetAll());

    public async Task<TResponse> GetById(Guid id)
         => _mapper.Map<TResponse>
        (await _repository.GetOneWhere(entity => entity.Id == id));

    public async Task<int> Count()
        => await _repository.Count();

    public virtual async Task<TResponse> Create(TRequest createViewModel)
    {
        var entityMapped = _mapper.Map<TEntity>(createViewModel);

        await _repository.Add(entityMapped);

        if (!await _unitOfWork.SaveChanges())
            throw new InvalidOperationException("Não foi possível salvar as alterações.");

        return _mapper.Map<TResponse>(entityMapped);
    }

    public virtual async Task<TResponse> Update(Guid id, TRequest updateViewModel)
    {
        var entity = await _repository.GetOneWhere(entity => entity.Id == id);
        if (entity is null)
            throw new InvalidOperationException($"Um(a) {nameof(entity)} não existe com o Id {id}.");

        var entityMapped = _mapper.Map<TEntity>(updateViewModel);

        _repository.Update(entityMapped);

        if (!await _unitOfWork.SaveChanges())
            throw new InvalidOperationException("Não foi possível salvar as alterações.");

        return _mapper.Map<TResponse>(entityMapped);
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        var entity = await _repository.GetOneWhere(entity => entity.Id == id);
        if (entity is null)
            throw new InvalidOperationException($"Um(a) {nameof(entity)} não existe com o Id {id}.");

        _repository.Delete(entity);

        if (!await _unitOfWork.SaveChanges())
            return false;

        return true;
    }

}