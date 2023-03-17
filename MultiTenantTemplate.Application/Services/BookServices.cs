using AutoMapper;
using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Books;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Domain.Transactions;

namespace MultiTenantTemplate.Application.Services;

public sealed class BookServices :
    BaseServices<Book, IBookRepository, RequestBookViewModel, ResponseBookViewModel>,
    IBookServices
{
    public BookServices(
        IBookRepository repository,
        IUnitOfWork unitOfWork, 
        IMapper mapper
        ) : base(repository, unitOfWork, mapper)
    { }
}