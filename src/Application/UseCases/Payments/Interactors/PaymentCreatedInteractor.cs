using Application.Abstractions.Interactors;
using Application.Messages.Events;

namespace Application.UseCases.Payments.Interactors;

public interface IPaymentCreatedInteractor : IInteractor<PaymentCreatedEvent>;

public class PaymentCreatedInteractor : IPaymentCreatedInteractor
{
    public Task InteractAsync(PaymentCreatedEvent command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}