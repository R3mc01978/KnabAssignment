namespace CryptoQuotation.Service.DataContracts.Contracts;

/// <summary>
/// Contains information about Quote currencies
/// </summary>
public class CryptoModel : AbstractModel
{
    /// <summary>
    /// The code of the crypto that the quote currencies relate to
    /// </summary>
    public string Ticker { get; set; } = string.Empty;

    /// <summary>
    /// List of Quote currencies
    /// </summary>
    public List<QuoteModel> QuoteCurrencies { get; } = new();
}