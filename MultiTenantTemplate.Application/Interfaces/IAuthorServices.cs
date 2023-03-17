using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.ViewModels.Authors;

namespace MultiTenantTemplate.Application.Interfaces;

public interface IAuthorServices 
    : IBaseServices<RequestAuthorViewModel, ResponseAuthorViewModel>
{ }