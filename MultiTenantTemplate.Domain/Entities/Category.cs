using MultiTenantTemplate.Domain.Core;

namespace MultiTenantTemplate.Domain.Entities;

public sealed class Category : Entity
{ 
    public string Description { get; set; } = string.Empty;

    public List<BookCategory> Books { get; set; } = null!;
}
