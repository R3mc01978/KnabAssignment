namespace CryptoQuotation.Service.Infra.Services.CoinMarketCap.Contracts;

public class CoinCapResponseModel
{
    public IDictionary<string, List<Dictionary<string, object>>> data { get; set; }
    public Status status { get; set; }
}

public class Data
{
    public IDictionary<string, object> data { get; set; }
}