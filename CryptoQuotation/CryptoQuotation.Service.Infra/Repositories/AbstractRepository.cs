
namespace CryptoQuotation.Service.Infra.Repositories;

public abstract class AbstractRepository
{
    protected AbstractRepository()
    {
    }

    public Task<bool> IsHealthy()
    {
        return Task.FromResult(true);
    }
}