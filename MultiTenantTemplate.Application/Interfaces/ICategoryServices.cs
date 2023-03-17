using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.ViewModels.Categories;

namespace MultiTenantTemplate.Application.Interfaces;

public interface ICategoryServices 
    : IBaseServices<RequestCategoryViewModel, ResponseCategoryViewModel>
{ }