using MultiTenantTemplate.Domain.Core;

namespace MultiTenantTemplate.Domain.Entities;

public sealed class Author : Entity
{
    public string Name { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public int Age => GetAge();

    public List<Book> Books { get; set; } = null!;

    private int GetAge()
        => DateTime.Now.DayOfYear > Birthday.DayOfYear
        ? DateTime.Now.Year - Birthday.Year
        : (DateTime.Now.Year - Birthday.Year) - 1;
}