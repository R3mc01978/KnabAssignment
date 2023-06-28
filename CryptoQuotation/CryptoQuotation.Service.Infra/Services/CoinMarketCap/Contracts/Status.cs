using System.Text.Json.Serialization;

namespace CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts;

public class Status
{
    [JsonPropertyName("error_message")] 
    public string ErrorMessage { get; set; } = string.Empty;
}