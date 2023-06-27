using CryptoQuotation.Service.Application.Common;
using OneOf;
using CryptoQuotation.Service.DataContracts;
using OneOf.Types;

namespace CryptoQuotation.Service.Application.Features.GetCryptoQuotations
{
    public class GetCryptoQuotationQuery : Query<OneOf<CryptoModel, NotFound>>
    {
        public string Ticker { get; set; } = string.Empty;
    }
}
