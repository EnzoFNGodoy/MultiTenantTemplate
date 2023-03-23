using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenantTemplate.Application.Interfaces;
using MultiTenantTemplate.Application.ViewModels.Users;

namespace MultTenantTemplate.WebApi.Controllers;

[Route("auth")]
[AllowAnonymous]
public sealed class LoginController : ControllerBase
{
    private readonly IUserServices _userServices;

    public LoginController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost()]
    public async Task<IActionResult> Login([FromBody] RequestUserLoginViewModel viewModel)
       => Ok(await _userServices.Login(viewModel));
}