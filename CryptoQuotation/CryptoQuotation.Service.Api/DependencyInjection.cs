using System.Reflection;
using CryptoQuotation.Service.DataContracts.Contracts;
using Microsoft.OpenApi.Models;

namespace CryptoQuotation.Service.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddSwaggerFor(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlSchemaFilename = $"{(typeof(AbstractModel)).Assembly.GetName().Name}.xml";

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlSchemaFilename));
            options.SupportNonNullableReferenceTypes();
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Knab Quote currency service",
                Description = "Returns quote currencies for the specified ticker"
            });
                
            options.UseOneOfForPolymorphism();
            options.UseAllOfToExtendReferenceSchemas();
            options.UseAllOfForInheritance();
            options.SelectDiscriminatorNameUsing(_ => "type");
            options.CustomSchemaIds(i => i.Name);
            options.EnableAnnotations();
        });

        return services;
    }
}