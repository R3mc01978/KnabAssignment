namespace CryptoQuotation.Service.Application.Entities;

public class Quote
{
    public string Currency{ get; set; } = string.Empty;
    public double Value { get; set; }
}