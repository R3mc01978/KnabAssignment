using System.Text.Json.Serialization;

namespace CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts;

public class LatestQuote
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = String.Empty;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = String.Empty;

    [JsonPropertyName("quote")]
    public IDictionary<string, Quote> Quote { get; set; } = new Dictionary<string, Quote>();
}