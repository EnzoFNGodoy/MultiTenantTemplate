using MultiTenantTemplate.Application.Core;
using MultiTenantTemplate.Application.ViewModels.Books;
using MultiTenantTemplate.Application.ViewModels.Categories;

namespace MultiTenantTemplate.Application.ViewModels.BooksCategories;

public sealed record ResponseBookCategoryViewModel : ResponseViewModel
{
    public ResponseBookViewModel Book { get; set; } = null!;
    public ResponseCategoryViewModel Category { get; set; } = null!;
}