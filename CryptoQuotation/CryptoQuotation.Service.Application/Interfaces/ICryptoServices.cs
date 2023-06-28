namespace CryptoQuotation.Service.Application.Interfaces;
using Entities;

public interface ICryptoServices
{
    Task<CryptoQuote?> GetQuoteCurrenciesAsync(string ticker);
}