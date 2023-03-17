using System.Linq.Expressions;

namespace MultiTenantTemplate.Domain.Core;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetOneWhere(Expression<Func<T, bool>> condition);
    Task<bool> Exists(Expression<Func<T, bool>> condition);
    Task<int> Count();

    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}