using Microsoft.EntityFrameworkCore;
using MultiTenantTemplate.Domain.Core;
using MultiTenantTemplate.Infra.Data.Context;
using System.Linq.Expressions;

namespace MultiTenantTemplate.Infra.Data.Core;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(LibraryContext context)
    {
        _dbSet = context.Set<T>();    
    }

    public virtual async Task<IEnumerable<T>> GetAll()
     => await _dbSet
     .AsNoTracking()
     .ToListAsync();

    public virtual async Task<T> GetOneWhere(Expression<Func<T, bool>> condition)
        => (await _dbSet
        .AsNoTracking()
        .SingleOrDefaultAsync(condition))!;

    public async Task<bool> Exists(Expression<Func<T, bool>> condition)
      => await _dbSet
      .AsNoTracking()
      .SingleOrDefaultAsync(condition) is not null;

    public async Task<int> Count()
       => await _dbSet.CountAsync();

    public async Task Add(T entity)
        => await _dbSet.AddAsync(entity);

    public void Update(T entity)
        => _dbSet.Update(entity);

    public void Delete(T entity)
        => _dbSet.Remove(entity);
}