using Domain.Entities;

namespace Application.Abstractions.Adapters;

public interface ICreateTradeAdapter
{
    Task CreateTrade(Trade trade, CancellationToken cancellationToken);
}