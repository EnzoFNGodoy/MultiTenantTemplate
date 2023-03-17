using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.ViewModels.Authors;
using MultiTenantTemplate.Application.ViewModels.Categories;

namespace MultiTenantTemplate.Application.ViewModels.Books;

public sealed record ResponseBookViewModel : ResponseViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ResponseAuthorViewModel Author { get; set; } = null!;
    public List<ResponseCategoryViewModel> Categories { get; set; } = null!;
}