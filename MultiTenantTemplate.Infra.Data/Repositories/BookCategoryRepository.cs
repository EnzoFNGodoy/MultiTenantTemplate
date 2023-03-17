using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Infra.Data.Context;
using MultiTenantTemplate.Infra.Data.Core;

namespace MultiTenantTemplate.Infra.Data.Repositories;

public sealed class BookCategoryRepository : BaseRepository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(LibraryContext context) : base(context)
    { }
}