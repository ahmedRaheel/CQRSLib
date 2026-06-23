using FluentValidation;

namespace LibraryService.Api.Features.Reservation.UpdateReservation;
public sealed class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.MemberId).NotNull();
        RuleFor(x => x.ReservedAt).NotNull();
    }
}