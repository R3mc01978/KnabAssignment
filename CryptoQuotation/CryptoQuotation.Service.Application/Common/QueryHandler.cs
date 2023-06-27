using MediatR;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.Logging;

namespace CryptoQuotation.Service.Application.Common;

public abstract class QueryHandler<TRequest, TModel> : IRequestHandler<TRequest, TModel>
    where TRequest : IRequest<TModel>
{
    protected readonly ILogger Logger;

    protected QueryHandler(ILogger logger)
    {
        Logger = logger;
    }

    [Pure]
    public virtual async Task<TModel> Handle([NotNull] TRequest request, CancellationToken cancellationToken)
    {
        using (Logger.BeginScope("[{Handler}]", GetType().Name))
        {
            try
            {
                return await HandleRequest(request, cancellationToken);
            }
            catch (Exception exception)
            {
                Logger.LogError(GetType().Name, request.ToString());

                return OnException(exception);
            }
        }
    }

    protected virtual TModel OnException(Exception exception)
    {
        throw exception;
    }

    protected abstract Task<TModel> HandleRequest(TRequest query, CancellationToken cancellationToken);
}