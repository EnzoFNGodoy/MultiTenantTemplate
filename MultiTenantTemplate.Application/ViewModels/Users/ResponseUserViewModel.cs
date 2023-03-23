using MultiTenantTemplate.Application.Core;

namespace MultiTenantTemplate.Application.ViewModels.Users;

public record ResponseUserViewModel : ResponseViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}