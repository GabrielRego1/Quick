using Application.Messages.Events;
using Application.UseCases.Abstractions.Interactors;

namespace Application.UseCases.Payment.Interactors;

public class PaymentCreatedInteractor:IPaymentCreatedInteractor
{
    public Task InteractAsync(PaymentCreatedEvent command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}