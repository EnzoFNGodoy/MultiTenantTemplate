using MultiTenantTemplate.Application.Core;

namespace MultiTenantTemplate.Application.ViewModels.Categories;

public sealed record RequestCategoryViewModel : RequestViewModel
{
    public string Description { get; set; } = string.Empty;
}