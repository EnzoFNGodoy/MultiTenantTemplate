using MultiTenantTemplate.Application.Core;

namespace MultiTenantTemplate.Application.ViewModels.BooksCategories;

public sealed record RequestBookCategoryViewModel : RequestViewModel
{
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }
}