using Microsoft.EntityFrameworkCore;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Infra.Data.Mappings;

namespace MultiTenantTemplate.Infra.Data.Context;

public sealed class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions options) 
        : base(options)
    { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<BookCategory> BooksCategories => Set<BookCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookCategoryMap());

        base.OnModelCreating(modelBuilder);
    }
}