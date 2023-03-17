using MultiTenantTemplate.Domain.Core;

namespace MultiTenantTemplate.Domain.Entities;

public sealed class Book : Entity
{
    public Guid AuthorId  { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Author Author { get; set; } = null!;
    public List<BookCategory> Categories { get; set; } = null!;
}