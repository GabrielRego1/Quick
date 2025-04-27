using Application.Messages.Commands;

namespace Application.Abstractions.Adapters;

public interface ICreateTradeAdapter
{
    Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken);
}