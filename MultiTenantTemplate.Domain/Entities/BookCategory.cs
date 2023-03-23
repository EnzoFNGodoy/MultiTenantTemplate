using MultiTenantTemplate.Domain.Core;

namespace MultiTenantTemplate.Domain.Entities;

public sealed class BookCategory : Entity
{
    public Guid CompanyId { get; set; }
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }

    public Book Book { get; set; } = null!;
    public Category Category { get; set; } = null!;
}