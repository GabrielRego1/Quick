namespace Application.Abstractions.Interactors;

public interface IInteractor<in TMessage>
{
    Task InteractAsync(TMessage command, CancellationToken cancellationToken);
}