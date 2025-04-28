using Application.Messages.Commands;

namespace Application.Abstractions.Adapters;

public interface ICreateTradeAdapter
{
    Task CreateTrade(CreateTradeCommand command, CancellationToken cancellationToken);
}