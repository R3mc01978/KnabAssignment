﻿namespace CryptoQuotation.Service.DataContracts;

/// <summary>
/// Quotation
/// </summary>
public class QuotationModel : AbstractModel
{
    /// <summary>
    /// Quote currency
    /// </summary>
    public string Currency{ get; set; } = string.Empty;

    /// <summary>
    /// Trading value
    /// </summary>
    public decimal Value { get; set; }
}