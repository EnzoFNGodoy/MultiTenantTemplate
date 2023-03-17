using Microsoft.EntityFrameworkCore;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Infra.Data.Context;
using MultiTenantTemplate.Infra.Data.Core;
using System.Linq.Expressions;

namespace MultiTenantTemplate.Infra.Data.Repositories;

public sealed class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(LibraryContext context) : base(context)
    { }

    public override async Task<IEnumerable<Book>> GetAll()
    => await _dbSet
        .Include(b => b.Author)
        .Include(b => b.Categories)
        .ThenInclude(bc => bc.Category)
        .AsNoTracking()
        .ToListAsync();

    public override async Task<Book> GetOneWhere(Expression<Func<Book, bool>> condition)
        => (await _dbSet
        .Include(b => b.Author)
        .Include(b => b.Categories)
        .ThenInclude(bc => bc.Category)
        .AsNoTracking()
        .SingleOrDefaultAsync(condition))!;
}