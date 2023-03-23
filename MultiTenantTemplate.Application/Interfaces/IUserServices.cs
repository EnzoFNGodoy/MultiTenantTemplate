using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.ViewModels.Users;

namespace MultiTenantTemplate.Application.Interfaces;
public interface IUserServices
    : IBaseServices<RequestUserViewModel, ResponseUserViewModel>
{
    Task<ResponseUserLoginViewModel> Login(RequestUserLoginViewModel viewModel);
}