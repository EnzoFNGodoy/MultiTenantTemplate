using AutoMapper;
using MultiTenantTemplate.Application.ViewModels.Authors;
using MultiTenantTemplate.Application.ViewModels.Books;
using MultiTenantTemplate.Application.ViewModels.BooksCategories;
using MultiTenantTemplate.Application.ViewModels.Categories;
using MultiTenantTemplate.Domain.Entities;

namespace MultiTenantTemplate.Application.AutoMapper;

public sealed class ViewModelToDomainProfile : Profile
{
    public ViewModelToDomainProfile()
    {
        CreateMap<RequestAuthorViewModel, Author>();
        CreateMap<RequestBookViewModel, Book>();
        CreateMap<RequestCategoryViewModel, Category>();
        CreateMap<RequestBookCategoryViewModel, BookCategory>();
    }
}