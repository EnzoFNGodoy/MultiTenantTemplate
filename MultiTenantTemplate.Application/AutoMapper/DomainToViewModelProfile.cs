using AutoMapper;
using MultiTenantTemplate.Application.ViewModels.Authors;
using MultiTenantTemplate.Application.ViewModels.Books;
using MultiTenantTemplate.Application.ViewModels.BooksCategories;
using MultiTenantTemplate.Application.ViewModels.Categories;
using MultiTenantTemplate.Application.ViewModels.Users;
using MultiTenantTemplate.Domain.Entities;

namespace MultiTenantTemplate.Application.AutoMapper;

public sealed class DomainToViewModelProfile : Profile
{
    public DomainToViewModelProfile()
    {
        CreateMap<User, ResponseUserLoginViewModel>();
        CreateMap<User, ResponseUserViewModel>();
        CreateMap<Author, ResponseAuthorViewModel>();
        CreateMap<Book, ResponseBookViewModel>();
        CreateMap<BookCategory, ResponseBookCategoryViewModel>();
        CreateMap<Category, ResponseCategoryViewModel>();
    }
}