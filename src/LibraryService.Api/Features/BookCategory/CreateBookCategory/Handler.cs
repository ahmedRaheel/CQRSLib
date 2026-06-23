using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.CreateBookCategory;
public sealed class CreateBookCategoryCommandHandler : IRequestHandler<CreateBookCategoryCommand, Result<BookCategoryDto>>
{
    private readonly IBookCategoryCommandRepository _commands;
    private readonly IBookCategoryQueryRepository _query;
    public CreateBookCategoryCommandHandler(IBookCategoryCommandRepository commands, IBookCategoryQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<BookCategoryDto>> Handle(CreateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = BookCategoryEntity.Create(request.BookId, request.CategoryId);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new BookCategoryDto(entity.Id, entity.BookId, entity.CategoryId);
        return Result<BookCategoryDto>.Success(response, "BookCategory successfully created.");
    }
}