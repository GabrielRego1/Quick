using Application.Abstractions.Interactors;
using Application.Messages.Events;

namespace Application.UseCases.Trade.Interactors;

public interface ITradeCreatedInteractor : IInteractor<TradeCreatedEvent>;

public class TradeCreatedInteractor : ITradeCreatedInteractor
{
    public Task InteractAsync(TradeCreatedEvent command, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}