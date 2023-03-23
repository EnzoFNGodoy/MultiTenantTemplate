using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.Services;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Domain.Transactions;
using MultiTenantTemplate.Infra.Data.Context;
using MultiTenantTemplate.Infra.Data.Repositories;
using MultiTenantTemplate.Infra.Data.Transactions;

namespace MultiTenantTemplate.Infra.CrossCutting.IoC;

public static class NativeInjector
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<LibraryContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IAuthorServices, AuthorServices>();
        services.AddScoped<IBookCategoryServices, BookCategoryServices>();
        services.AddScoped<IBookServices, BookServices>();
        services.AddScoped<ICategoryServices, CategoryServices>();
    }
}