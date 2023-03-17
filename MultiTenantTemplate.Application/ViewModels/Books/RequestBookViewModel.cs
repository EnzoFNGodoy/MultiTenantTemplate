using MultiTenantTemplate.Application.Core;

namespace MultiTenantTemplate.Application.ViewModels.Books;

public sealed record RequestBookViewModel : RequestViewModel
{
    public Guid AuthorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}