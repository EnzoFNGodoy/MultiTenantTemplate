using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.ViewModels.BooksCategories;

namespace MultiTenantTemplate.Application.Interfaces;

public interface IBookCategoryServices : 
    IBaseServices<RequestBookCategoryViewModel, ResponseBookCategoryViewModel>
{ }