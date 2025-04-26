using Application.Abstractions.Interactors;
using Application.Messages.Events;

namespace Application.UseCases.Trade.Interactors.Abstractions;

public interface IPaymentCreatedInteractor : IInteractor<PaymentCreatedEvent>;