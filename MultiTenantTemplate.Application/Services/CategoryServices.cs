using AutoMapper;
using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Categories;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Domain.Transactions;

namespace MultiTenantTemplate.Application.Services;

public sealed class CategoryServices :
    BaseServices<Category, ICategoryRepository, RequestCategoryViewModel, ResponseCategoryViewModel>,
    ICategoryServices
{
    public CategoryServices(
        ICategoryRepository repository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper
        ) : base(repository, unitOfWork, mapper)
    { }
}