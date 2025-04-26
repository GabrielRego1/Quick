using Application.Messages.Events;
using Application.UseCases.Trade.Interactors.Abstractions;

namespace Application.UseCases.Trade.Interactors;

public class TradeCreatedInteractor: ITradeCreatedInteractor
{
    public Task InteractAsync(TradeCreatedEvent command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}