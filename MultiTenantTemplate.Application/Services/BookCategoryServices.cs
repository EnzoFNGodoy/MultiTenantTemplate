using AutoMapper;
using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.BooksCategories;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Domain.Transactions;

namespace MultiTenantTemplate.Application.Services;

public sealed class BookCategoryServices :
    BaseServices<BookCategory, IBookCategoryRepository, RequestBookCategoryViewModel, ResponseBookCategoryViewModel>,
    IBookCategoryServices
{
    public BookCategoryServices(
        IBookCategoryRepository repository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper
        ) : base(repository, unitOfWork, mapper)
    { }
}