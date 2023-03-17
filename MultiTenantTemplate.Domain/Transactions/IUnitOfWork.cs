namespace MultiTenantTemplate.Domain.Transactions;

public interface IUnitOfWork
{
    Task<bool> SaveChanges();
}