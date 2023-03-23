using System.Security.Claims;

namespace MultiTenant.Infra.CrossCutting.Auth.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid CompanyId(this ClaimsPrincipal claims)
    {
        try
        {
            var value = claims?.FindFirst("CompanyId")?.Value;
            return Guid.Parse(value!);
        }
        catch
        {
            return Guid.Empty;
        }
    }
}