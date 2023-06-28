namespace CryptoQuotation.Service.DataContracts.Contracts;

/// <summary>
/// Quotation
/// </summary>
public class QuoteModel : AbstractModel
{
    /// <summary>
    /// Quote currency
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Trading value
    /// </summary>
    public double Value { get; set; }
}