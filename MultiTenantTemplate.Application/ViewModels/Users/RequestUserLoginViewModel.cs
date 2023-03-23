using MultiTenantTemplate.Application.Core;

namespace MultiTenantTemplate.Application.ViewModels.Users;

public sealed record RequestUserLoginViewModel : RequestViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}