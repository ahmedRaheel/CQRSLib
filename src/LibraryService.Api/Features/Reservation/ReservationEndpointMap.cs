using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Reservation.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.Reservation.CreateReservation;
using LibraryService.Api.Features.Reservation.UpdateReservation;
using LibraryService.Api.Features.Reservation.DeleteReservation;
using LibraryService.Api.Features.Reservation.GetReservationById;
using LibraryService.Api.Features.Reservation.GetReservationsPaged;

namespace LibraryService.Api.Features.Reservation;
internal static class ReservationEndpointConstants
{
    public const string BaseRoute = "/api/v1/reservations";
    public const string Tag = "Reservations";
    public const string CreateRouteName = "CreateReservation";
    public const string UpdateRouteName = "UpdateReservation";
    public const string DeleteRouteName = "DeleteReservation";
    public const string GetByIdRouteName = "GetReservationById";
    public const string GetPagedRouteName = "GetReservationPaged";
}

public static class ReservationEndpointMap
{
    public static IEndpointRouteBuilder MapReservationEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ReservationEndpointConstants.BaseRoute).WithTags(ReservationEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(ReservationEndpointConstants.CreateRouteName).Produces<ReservationDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(ReservationEndpointConstants.UpdateRouteName).Produces<ReservationDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(ReservationEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(ReservationEndpointConstants.GetByIdRouteName).Produces<ReservationDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(ReservationEndpointConstants.GetPagedRouteName).Produces<PagedResult<ReservationDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateReservationRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateReservationCommand(request.BookId, request.MemberId, request.ReservedAt);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(ReservationEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateReservationRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateReservationCommand(id, request.BookId, request.MemberId, request.ReservedAt);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteReservationCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetReservationByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetReservationsPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}