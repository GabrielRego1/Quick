using Application.Messages.Commands;

namespace Application.UseCases.Abstractions;

public interface ICreateTradeUseCase
{
    Task ExecuteAsync(CreateTradeCommand command, CancellationToken cancellationToken);
}