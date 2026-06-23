using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor.CreateBookAuthor;
public sealed class CreateBookAuthorCommandHandler : IRequestHandler<CreateBookAuthorCommand, Result<BookAuthorDto>>
{
    private readonly IBookAuthorCommandRepository _commands;
    private readonly IBookAuthorQueryRepository _query;
    public CreateBookAuthorCommandHandler(IBookAuthorCommandRepository commands, IBookAuthorQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<BookAuthorDto>> Handle(CreateBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = BookAuthorEntity.Create(request.BookId, request.AuthorId);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new BookAuthorDto(entity.Id, entity.BookId, entity.AuthorId);
        return Result<BookAuthorDto>.Success(response, "BookAuthor successfully created.");
    }
}