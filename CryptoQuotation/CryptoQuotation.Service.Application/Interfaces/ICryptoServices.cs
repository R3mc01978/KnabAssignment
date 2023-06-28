namespace CryptoQuotation.Service.Application.Interfaces;
using Entities;

public interface ICryptoServices
{
    Task<CryptoQuotation?> GetQuoteCurrenciesAsync(string ticker);
}