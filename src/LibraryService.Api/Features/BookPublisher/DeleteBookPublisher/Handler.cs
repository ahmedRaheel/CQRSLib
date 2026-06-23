using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.DeleteBookPublisher;
public sealed class DeleteBookPublisherCommandHandler : IRequestHandler<DeleteBookPublisherCommand, Result<Unit>>
{
    private readonly IBookPublisherCommandRepository _commands;
    private readonly IBookPublisherQueryRepository _query;
    public DeleteBookPublisherCommandHandler(IBookPublisherCommandRepository commands, IBookPublisherQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeleteBookPublisherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("BookPublisher with ID {request.Id} was not found.");
        await _commands.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "BookPublisher successfully deleted.");
    }
}