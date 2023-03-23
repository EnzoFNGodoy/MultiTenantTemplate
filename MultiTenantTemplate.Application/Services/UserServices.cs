using AutoMapper;
using MultiTenantTemplate.Application.Auth;
using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Users;
using MultiTenantTemplate.Domain.Entities;
using MultiTenantTemplate.Domain.Interfaces;
using MultiTenantTemplate.Domain.Transactions;

namespace MultiTenantTemplate.Application.Services;
public sealed class UserServices :
    BaseServices<User, IUserRepository, RequestUserViewModel, ResponseUserViewModel>,
    IUserServices
{
    public UserServices(
        IUserRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : base(repository, unitOfWork, mapper)
    { }

    public async Task<ResponseUserLoginViewModel> Login(RequestUserLoginViewModel viewModel)
    {
        var user = await _repository.GetOneWhere(
            u => u.Email == viewModel.Email 
            && u.Password == viewModel.Password)
            ?? throw new InvalidOperationException("Credenciais erradas! Favor tentar novamente.");

        var response = _mapper.Map<ResponseUserLoginViewModel>(user);
        response.Token = TokenServices.GenerateToken(user);

        return response;
    }
}