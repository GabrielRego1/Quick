using Application.Messages.Events;
using Application.UseCases.Trade.Interactors.Abstractions;

namespace Application.UseCases.Trade.Interactors;

public class PaymentCreatedInteractor:IPaymentCreatedInteractor
{
    public Task InteractAsync(PaymentCreatedEvent command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}