namespace CryptoQuotation.Service.Application.Entities;

public class Quotation
{
    public string Currency{ get; set; } = string.Empty;
    public double Value { get; set; }
}