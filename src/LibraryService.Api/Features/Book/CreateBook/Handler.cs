using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Book.CreateBook;
public sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<BookDto>>
{
    private readonly IBookCommandRepository _commands;
    private readonly IBookQueryRepository _query;
    public CreateBookCommandHandler(IBookCommandRepository commands, IBookQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<BookDto>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = BookEntity.Create(request.Isbn, request.Title);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new BookDto(entity.Id, entity.Isbn, entity.Title);
        return Result<BookDto>.Success(response, "Book successfully created.");
    }
}