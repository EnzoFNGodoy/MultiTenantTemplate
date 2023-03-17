using EasyDocs.WebApi.Configurations.Swagger;
using Microsoft.AspNetCore.OData;
using MultTenantTemplate.WebApi.Configurations;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(opt =>
    {
        opt.Select().Filter().OrderBy().SetMaxTop(100).SkipToken().Expand().Count();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();

// Configuring SqlServer Database
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Implementing IoC
builder.Services.AddDependencyInjectionConfiguration();

// Configuring Swagger
builder.Services.AddSwaggerConfiguration();

// Configuring AutoMapper
builder.Services.AddAutoMapperConfiguration();

var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
});

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
