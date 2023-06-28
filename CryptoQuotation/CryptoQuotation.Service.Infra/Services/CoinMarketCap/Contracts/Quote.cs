using System.Text.Json.Serialization;

namespace CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts
{
    public class Quote
    {
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
