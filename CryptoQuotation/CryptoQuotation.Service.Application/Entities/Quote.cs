namespace CryptoQuotation.Service.Application.Entities;

public class Quote
{
    public Quote(string currency, double value)
    {
        Currency = currency;
        Value = value;
    }
    public string Currency{ get; }
    public double Value { get; }
}