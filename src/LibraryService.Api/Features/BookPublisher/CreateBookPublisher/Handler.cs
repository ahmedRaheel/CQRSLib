using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.CreateBookPublisher;
public sealed class CreateBookPublisherCommandHandler : IRequestHandler<CreateBookPublisherCommand, Result<BookPublisherDto>>
{
    private readonly IBookPublisherCommandRepository _commands;
    private readonly IBookPublisherQueryRepository _query;
    public CreateBookPublisherCommandHandler(IBookPublisherCommandRepository commands, IBookPublisherQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<BookPublisherDto>> Handle(CreateBookPublisherCommand request, CancellationToken cancellationToken)
    {
        var entity = BookPublisherEntity.Create(request.BookId, request.PublisherId);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new BookPublisherDto(entity.Id, entity.BookId, entity.PublisherId);
        return Result<BookPublisherDto>.Success(response, "BookPublisher successfully created.");
    }
}