using Newtonsoft.Json;

namespace CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class LatestQuote
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int is_active { get; set; }
        public int is_fiat { get; set; }
        public int circulating_supply { get; set; }
        public int total_supply { get; set; }
        public int max_supply { get; set; }
        public DateTime date_added { get; set; }
        public int num_market_pairs { get; set; }
        public int cmc_rank { get; set; }
        public DateTime last_updated { get; set; }
        public List<string> tags { get; set; }
        public object platform { get; set; }
        public object self_reported_circulating_supply { get; set; }
        public object self_reported_market_cap { get; set; }
        public Quote quote { get; set; }
    }

    public class Quote
    {
        public USD USD { get; set; }
    }

    public class Status
    {
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
        public string error_message { get; set; }
        public int elapsed { get; set; }
        public int credit_count { get; set; }
        public string notice { get; set; }
    }

    public class USD
    {
        public double price { get; set; }
        public double volume_24h { get; set; }
        public double volume_change_24h { get; set; }
        public double percent_change_1h { get; set; }
        public double percent_change_24h { get; set; }
        public double percent_change_7d { get; set; }
        public double percent_change_30d { get; set; }
        public double market_cap { get; set; }
        public int market_cap_dominance { get; set; }
        public double fully_diluted_market_cap { get; set; }
        public DateTime last_updated { get; set; }
    }


}
