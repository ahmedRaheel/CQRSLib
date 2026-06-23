using FluentValidation;

namespace LibraryService.Api.Features.Reservation.CreateReservation;
public sealed class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.MemberId).NotNull();
        RuleFor(x => x.ReservedAt).NotNull();
    }
}