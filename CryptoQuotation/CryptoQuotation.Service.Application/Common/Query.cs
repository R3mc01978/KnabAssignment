using MediatR;
using System.Reflection;
using System.Text;

namespace CryptoQuotation.Service.Application.Common;

public abstract class Query<TQueryModel> : IRequest<TQueryModel>
{
    public override string ToString()
    {
        var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();

        var builder = new StringBuilder();
        builder.Append($"{GetType().Name}");
        properties.ForEach((p) =>
        {
            builder.Append($" {p.Name} : {p.GetValue(this)}");
        });

        return builder.ToString();
    }
}