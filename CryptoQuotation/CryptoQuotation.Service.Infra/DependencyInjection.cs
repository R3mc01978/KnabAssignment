using CryptoQuotation.Service.Application.Interfaces;
using CryptoQuotation.Service.Infra.Services.CoinMarketCap;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoQuotation.Service.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICryptoServices, CryptoService>();

        return services;
    }
}