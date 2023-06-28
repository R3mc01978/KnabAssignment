namespace CryptoQuotation.Service.Application.Entities;

public class CryptoQuote
{
    public CryptoQuote(string ticker)
    {
        Ticker = ticker;
    }

    public string Ticker { get; }

    public List<Quote> QuoteCurrencies { get; } = new();

    public void AddQuoteCurrency(string currency, double value)
    {
        if (QuoteCurrencies.Exists(x => x.Currency == currency))
        {
            return;
        }

        QuoteCurrencies.Add(new Quote(currency, value));
    }
}