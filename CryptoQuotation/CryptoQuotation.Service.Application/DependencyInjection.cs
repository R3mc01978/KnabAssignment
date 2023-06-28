using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoQuotation.Service.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, Assembly assembly)
    {
        // MediatR Cmd / Qry / Handlers
        services.AddMediatR((x) =>
        {
            x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            x.RegisterServicesFromAssembly(assembly);
        });

        return services;
    }
}