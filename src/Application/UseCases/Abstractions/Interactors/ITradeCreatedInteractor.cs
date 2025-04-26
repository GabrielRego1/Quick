using Application.Abstractions.Interactors;
using Application.Messages.Events;

namespace Application.UseCases.Abstractions.Interactors;

public interface ITradeCreatedInteractor : IInteractor<TradeCreatedEvent>;