using Application.Abstractions.Interactors;
using Domain.Events;

namespace Application.UseCases.Trades.Interactors;

public interface ITradeInitiatedInteractor : IInteractor<TradeInitiated>;

public class TradeInitiatedInteractor : ITradeInitiatedInteractor
{
    public Task InteractAsync(TradeInitiated command, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}