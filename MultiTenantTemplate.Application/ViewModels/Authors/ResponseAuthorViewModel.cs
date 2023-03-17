using MultiTenantTemplate.Application.Core;

namespace MultiTenantTemplate.Application.ViewModels.Authors;

public sealed record ResponseAuthorViewModel : ResponseViewModel
{
    public string Name { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public int Age { get; set; }
}