using MultiTenantTemplate.Application.Core;

namespace MultiTenantTemplate.Application.ViewModels.Categories;

public sealed record ResponseCategoryViewModel : ResponseViewModel
{
    public string Description { get; set; } = string.Empty;
}