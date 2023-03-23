namespace MultiTenantTemplate.Application.ViewModels.Users;

public sealed record ResponseUserLoginViewModel : ResponseUserViewModel
{
    public string Token { get; set; } = string.Empty;
}