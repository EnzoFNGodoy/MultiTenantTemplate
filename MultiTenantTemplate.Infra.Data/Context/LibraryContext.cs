using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiTenant.Infra.CrossCutting.Auth.Extensions;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Infra.Data.Mappings;
using System.Diagnostics;

namespace MultiTenantTemplate.Infra.Data.Context;

public sealed class LibraryContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LibraryContext(
        DbContextOptions<LibraryContext> options,
        IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<BookCategory> BooksCategories => Set<BookCategory>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);

        if (optionsBuilder.IsConfigured)
            return;

        var connectionString = string.Empty;

        if (_httpContextAccessor.HttpContext is not null)
        {
            var companyId = _httpContextAccessor.HttpContext.User.CompanyId();

            // Só um exemplo, não usar em PROD!
            connectionString = _configuration.GetConnectionString(companyId == Guid.Empty
                ? "LibraryConnection"
                : $"Company-{companyId}");

            optionsBuilder.UseSqlServer(connectionString);
            return;
        }

        connectionString = _configuration.GetConnectionString("LibraryConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookCategoryMap());

        if (_httpContextAccessor.HttpContext is not null)
        {
            var company = _httpContextAccessor.HttpContext.User.CompanyId();

            modelBuilder.Entity<User>()
                        .HasQueryFilter(x => EF.Property<Guid>(x, "CompanyId") == company);
            modelBuilder.Entity<Author>()
                        .HasQueryFilter(x => EF.Property<Guid>(x, "CompanyId") == company);
            modelBuilder.Entity<Book>()
                        .HasQueryFilter(x => EF.Property<Guid>(x, "CompanyId") == company);
            modelBuilder.Entity<Category>()
                        .HasQueryFilter(x => EF.Property<Guid>(x, "CompanyId") == company);
            modelBuilder.Entity<BookCategory>()
                        .HasQueryFilter(x => EF.Property<Guid>(x, "CompanyId") == company);
        }

        base.OnModelCreating(modelBuilder);
    }
}