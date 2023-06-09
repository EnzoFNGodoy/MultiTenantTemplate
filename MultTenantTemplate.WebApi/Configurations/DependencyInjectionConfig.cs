﻿using MultiTenantTemplate.Infra.CrossCutting.IoC;

namespace MultTenantTemplate.WebApi.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if(services is null) throw new ArgumentNullException(nameof(services));

        services.RegisterServices();
    }
}