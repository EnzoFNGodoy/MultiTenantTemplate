using MultiTenantTemplate.Domain.Transactions;
using MultiTenantTemplate.Infra.Data.Context;

namespace MultiTenantTemplate.Infra.Data.Transactions;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly LibraryContext _context;

    public UnitOfWork(LibraryContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveChanges()
        => await _context.SaveChangesAsync() > 0;
}