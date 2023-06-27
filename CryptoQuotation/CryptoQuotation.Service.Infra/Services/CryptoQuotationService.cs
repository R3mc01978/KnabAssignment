using CryptoQuotation.Service.Application.Interfaces;

namespace CryptoQuotation.Service.Infra.Services;

public class CryptoQuotationService : ICryptoServices
{
    public async Task<Application.Entities.CryptoQuotation?> GetQuotationsAsync(string ticker)
    {
        // TODO implement coinbase servicecall
        throw new NotImplementedException();
    }
}