using System.Text.Json.Serialization;

namespace CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts;

public class CoinCapResponse
{
    [JsonPropertyName("data")]
    public IDictionary<string, List<LatestQuote>> Data { get; set; } = new Dictionary<string, List<LatestQuote>>();

    [JsonPropertyName("status")] 
    public Status Status { get; set; } = new();
}