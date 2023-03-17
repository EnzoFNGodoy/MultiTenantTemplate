using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.ViewModels.Books;

namespace MultiTenantTemplate.Application.Interfaces;

public interface IBookServices 
    : IBaseServices<RequestBookViewModel, ResponseBookViewModel>
{ }