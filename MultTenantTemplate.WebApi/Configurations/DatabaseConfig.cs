using Microsoft.EntityFrameworkCore;
using MultiTenantTemplate.Infra.Data.Context;
using System.Runtime.CompilerServices;

namespace MultTenantTemplate.WebApi.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if(services is null) throw new ArgumentNullException(nameof(services));

        var connectionString = configuration.GetConnectionString("LibraryConnection");

        services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(connectionString));
    } 
}