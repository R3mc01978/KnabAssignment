namespace CryptoQuotation.Service.Application.Interfaces;
using Entities;

public interface ICryptoServices
{
    Task<CryptoQuotation?> GetQuotationsAsync(string ticker);
}