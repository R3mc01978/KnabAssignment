namespace CryptoQuotation.Service.Application.Entities;

public class CryptoQuotation
{
    public CryptoQuotation(string ticker)
    {
        Ticker = ticker;
    }

    public string Ticker { get; }

    public List<Quotation> QuoteCurrencies { get; } = new();

    public void AddQuoteCurrency(string currency, double value)
    {
        if (QuoteCurrencies.Exists(x => x.Currency == currency))
        {
            return;
        }

        var item = new Quotation
        {
            Currency = currency,
            Value = value
        };

        QuoteCurrencies.Add(item);
    }
}