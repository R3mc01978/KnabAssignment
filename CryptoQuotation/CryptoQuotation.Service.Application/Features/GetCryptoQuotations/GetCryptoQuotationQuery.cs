using CryptoQuotation.Service.Application.Common;
using CryptoQuotation.Service.DataContracts.Contracts;
using OneOf;
using OneOf.Types;

namespace CryptoQuotation.Service.Application.Features.GetCryptoQuotations;

public class GetCryptoQuotationQuery : Query<OneOf<CryptoModel, NotFound>>
{
    public string Ticker { get; set; } = string.Empty;
}